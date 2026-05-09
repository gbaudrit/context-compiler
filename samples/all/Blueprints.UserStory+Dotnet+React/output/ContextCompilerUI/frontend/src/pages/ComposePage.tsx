import { useCompose } from '@/context/ComposeContext';
import { catalogApi } from '@/services/catalogApi';
import styles from './ComposePage.module.css';

export function ComposePage() {
  const { state, toggleModule, togglePack, toggleBlueprint, setCompiling, setResult, setError, reset } = useCompose();

  const total = state.moduleIds.length + state.packIds.length + state.blueprintIds.length;

  async function handleCompile() {
    if (total === 0) return;
    setCompiling(true);
    try {
      const result = await catalogApi.compile({
        moduleIds: state.moduleIds,
        packIds: state.packIds,
        blueprintIds: state.blueprintIds,
      });
      setResult(result);
    } catch (err: unknown) {
      setError(err instanceof Error ? err.message : String(err));
    }
  }

  return (
    <div className={styles.page}>
      <div className={styles.header}>
        <div>
          <h1 className={styles.heading}>Composer un contexte</h1>
          <p className={styles.sub}>Sélectionnez vos modules, packs et blueprints depuis le catalogue, puis compilez.</p>
        </div>
        <div className={styles.actions}>
          <button className="btn-ghost" onClick={reset} disabled={total === 0}>
            Réinitialiser
          </button>
          <button className="btn-primary" onClick={handleCompile} disabled={total === 0 || state.isCompiling}>
            {state.isCompiling ? 'Compilation…' : `Compiler (${total} élément${total > 1 ? 's' : ''})`}
          </button>
        </div>
      </div>

      {state.errorMessage && (
        <div className={styles.errorBanner}>{state.errorMessage}</div>
      )}

      {state.compileResult && (
        <div className={styles.successBanner}>
          Compilation réussie — rendez-vous dans <strong>Prévisualiser</strong>.
        </div>
      )}

      <div className={styles.columns}>
        <Section title="Blueprints sélectionnés" items={state.blueprintIds} onRemove={id => toggleBlueprint(id, false)} />
        <Section title="Packs sélectionnés"      items={state.packIds}      onRemove={id => togglePack(id, false)} />
        <Section title="Modules sélectionnés"    items={state.moduleIds}    onRemove={id => toggleModule(id, false)} />
      </div>

      {total === 0 && (
        <p className={styles.empty}>
          Aucun élément sélectionné. Parcourez le catalogue dans les onglets Modules, Packs et Blueprints.
        </p>
      )}
    </div>
  );
}

function Section({ title, items, onRemove }: { title: string; items: string[]; onRemove: (id: string) => void }) {
  if (items.length === 0) return null;
  return (
    <div className={styles.section}>
      <h3 className={styles.sectionTitle}>{title} ({items.length})</h3>
      <ul className={styles.chips}>
        {items.map(id => (
          <li key={id} className={styles.chip}>
            <span>{id.split('.').at(-1)}</span>
            <button className={styles.remove} onClick={() => onRemove(id)} title="Retirer">✕</button>
          </li>
        ))}
      </ul>
    </div>
  );
}
