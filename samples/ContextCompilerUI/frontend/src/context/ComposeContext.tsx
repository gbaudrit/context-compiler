import { createContext, useContext, useReducer, useCallback } from 'react';
import type { ReactNode } from 'react';
import type { CompileResultDto } from '@/types/catalog';

// --- State shape ---
interface ComposeState {
  moduleIds: string[];
  packIds: string[];
  blueprintIds: string[];
  compileResult: CompileResultDto | null;
  isCompiling: boolean;
  errorMessage: string | null;
}

type Action =
  | { type: 'ADD_MODULE'; id: string }
  | { type: 'REMOVE_MODULE'; id: string }
  | { type: 'ADD_PACK'; id: string }
  | { type: 'REMOVE_PACK'; id: string }
  | { type: 'ADD_BLUEPRINT'; id: string }
  | { type: 'REMOVE_BLUEPRINT'; id: string }
  | { type: 'COMPILE_START' }
  | { type: 'COMPILE_SUCCESS'; result: CompileResultDto }
  | { type: 'COMPILE_ERROR'; message: string }
  | { type: 'RESET' };

const initialState: ComposeState = {
  moduleIds: [],
  packIds: [],
  blueprintIds: [],
  compileResult: null,
  isCompiling: false,
  errorMessage: null,
};

function toggle(arr: string[], id: string, add: boolean): string[] {
  return add ? [...new Set([...arr, id])] : arr.filter(x => x !== id);
}

function reducer(state: ComposeState, action: Action): ComposeState {
  switch (action.type) {
    case 'ADD_MODULE':    return { ...state, moduleIds:    toggle(state.moduleIds,    action.id, true) };
    case 'REMOVE_MODULE': return { ...state, moduleIds:    toggle(state.moduleIds,    action.id, false) };
    case 'ADD_PACK':      return { ...state, packIds:      toggle(state.packIds,      action.id, true) };
    case 'REMOVE_PACK':   return { ...state, packIds:      toggle(state.packIds,      action.id, false) };
    case 'ADD_BLUEPRINT': return { ...state, blueprintIds: toggle(state.blueprintIds, action.id, true) };
    case 'REMOVE_BLUEPRINT': return { ...state, blueprintIds: toggle(state.blueprintIds, action.id, false) };
    case 'COMPILE_START': return { ...state, isCompiling: true, errorMessage: null };
    case 'COMPILE_SUCCESS': return { ...state, isCompiling: false, compileResult: action.result };
    case 'COMPILE_ERROR': return { ...state, isCompiling: false, errorMessage: action.message };
    case 'RESET': return initialState;
    default: return state;
  }
}

// --- Context ---
interface ComposeContextValue {
  state: ComposeState;
  toggleModule: (id: string, selected: boolean) => void;
  togglePack: (id: string, selected: boolean) => void;
  toggleBlueprint: (id: string, selected: boolean) => void;
  setCompiling: (on: boolean) => void;
  setResult: (result: CompileResultDto) => void;
  setError: (msg: string) => void;
  reset: () => void;
}

const ComposeContext = createContext<ComposeContextValue | null>(null);

export function ComposeProvider({ children }: { children: ReactNode }) {
  const [state, dispatch] = useReducer(reducer, initialState);

  const toggleModule    = useCallback((id: string, s: boolean) => dispatch({ type: s ? 'ADD_MODULE'    : 'REMOVE_MODULE',    id }), []);
  const togglePack      = useCallback((id: string, s: boolean) => dispatch({ type: s ? 'ADD_PACK'      : 'REMOVE_PACK',      id }), []);
  const toggleBlueprint = useCallback((id: string, s: boolean) => dispatch({ type: s ? 'ADD_BLUEPRINT' : 'REMOVE_BLUEPRINT', id }), []);
  const setCompiling    = useCallback((on: boolean) => dispatch(on ? { type: 'COMPILE_START' } : { type: 'RESET' }), []);
  const setResult       = useCallback((result: CompileResultDto) => dispatch({ type: 'COMPILE_SUCCESS', result }), []);
  const setError        = useCallback((message: string) => dispatch({ type: 'COMPILE_ERROR', message }), []);
  const reset           = useCallback(() => dispatch({ type: 'RESET' }), []);

  return (
    <ComposeContext value={{ state, toggleModule, togglePack, toggleBlueprint, setCompiling, setResult, setError, reset }}>
      {children}
    </ComposeContext>
  );
}

export function useCompose(): ComposeContextValue {
  const ctx = useContext(ComposeContext);
  if (!ctx) throw new Error('useCompose must be used inside <ComposeProvider>');
  return ctx;
}
