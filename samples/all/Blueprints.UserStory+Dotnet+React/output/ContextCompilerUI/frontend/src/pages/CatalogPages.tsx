import { useState, useMemo } from 'react';
import { useAsync } from '@/hooks/useAsync';
import { catalogApi } from '@/services/catalogApi';
import { useCompose } from '@/context/ComposeContext';
import { CatalogCard } from '@/components/CatalogCard/CatalogCard';
import styles from './CatalogPage.module.css';

export function ModulesPage() {
  const { data: modules, loading, error } = useAsync(catalogApi.getModules);
  const { state, toggleModule } = useCompose();
  const [search, setSearch] = useState('');
  const [category, setCategory] = useState('');

  const categories = useMemo(
    () => [...new Set(modules?.map(m => m.category) ?? [])],
    [modules]
  );

  const filtered = useMemo(
    () => (modules ?? []).filter(m =>
      (!search || m.name.toLowerCase().includes(search.toLowerCase()) || m.description.toLowerCase().includes(search.toLowerCase())) &&
      (!category || m.category === category)
    ),
    [modules, search, category]
  );

  if (loading) return <p className={styles.status}>Chargement des modules…</p>;
  if (error)   return <p className={styles.error}>Erreur : {error}</p>;

  return (
    <div className={styles.page}>
      <h1 className={styles.heading}>Modules</h1>
      <p className={styles.sub}>Capacités atomiques du pipeline Context Compiler</p>

      <div className={styles.controls}>
        <input
          className={styles.search}
          placeholder="Rechercher…"
          value={search}
          onChange={e => setSearch(e.target.value)}
        />
        <select className={styles.select} value={category} onChange={e => setCategory(e.target.value)}>
          <option value="">Toutes les catégories</option>
          {categories.map(c => <option key={c} value={c}>{c}</option>)}
        </select>
      </div>

      <div className={styles.grid}>
        {filtered.map(m => (
          <CatalogCard
            key={m.id}
            id={m.id}
            title={m.name}
            description={m.description}
            badge={m.category}
            selected={state.moduleIds.includes(m.id)}
            onToggle={toggleModule}
          />
        ))}
        {filtered.length === 0 && <p className={styles.empty}>Aucun module trouvé.</p>}
      </div>
    </div>
  );
}

export function PacksPage() {
  const { data: packs, loading, error } = useAsync(catalogApi.getPacks);
  const { data: modules } = useAsync(catalogApi.getModules);
  const { state, togglePack } = useCompose();
  const [search, setSearch] = useState('');

  const moduleMap = useMemo(
    () => Object.fromEntries((modules ?? []).map(m => [m.id, m.name])),
    [modules]
  );

  const filtered = (packs ?? []).filter(p =>
    !search || p.name.toLowerCase().includes(search.toLowerCase())
  );

  if (loading) return <p className={styles.status}>Chargement des packs…</p>;
  if (error)   return <p className={styles.error}>Erreur : {error}</p>;

  return (
    <div className={styles.page}>
      <h1 className={styles.heading}>Packs</h1>
      <p className={styles.sub}>Compositions prêtes à l'emploi de modules cohérents</p>

      <div className={styles.controls}>
        <input className={styles.search} placeholder="Rechercher…" value={search} onChange={e => setSearch(e.target.value)} />
      </div>

      <div className={styles.grid}>
        {filtered.map(p => (
          <CatalogCard
            key={p.id}
            id={p.id}
            title={p.name}
            description={`${p.description}\n\nModules inclus : ${p.moduleIds.map(id => moduleMap[id] ?? id).join(', ')}`}
            selected={state.packIds.includes(p.id)}
            onToggle={togglePack}
          />
        ))}
        {filtered.length === 0 && <p className={styles.empty}>Aucun pack trouvé.</p>}
      </div>
    </div>
  );
}

export function BlueprintsPage() {
  const { data: blueprints, loading, error } = useAsync(catalogApi.getBlueprints);
  const { state, toggleBlueprint } = useCompose();
  const [expanded, setExpanded] = useState<string | null>(null);
  const [search, setSearch] = useState('');

  const filtered = (blueprints ?? []).filter(b =>
    !search || b.name.toLowerCase().includes(search.toLowerCase())
  );

  if (loading) return <p className={styles.status}>Chargement des blueprints…</p>;
  if (error)   return <p className={styles.error}>Erreur : {error}</p>;

  return (
    <div className={styles.page}>
      <h1 className={styles.heading}>Blueprints</h1>
      <p className={styles.sub}>Solutions prêtes à l'emploi pour des cas d'usage précis</p>

      <div className={styles.controls}>
        <input className={styles.search} placeholder="Rechercher…" value={search} onChange={e => setSearch(e.target.value)} />
      </div>

      <div className={styles.list}>
        {filtered.map(bp => (
          <div key={bp.id} className={`${styles.bpCard} ${state.blueprintIds.includes(bp.id) ? styles.selected : ''}`}>
            <div className={styles.bpHeader}>
              <div>
                <span className={styles.bpTitle}>{bp.name}</span>
                <span className={styles.bpSteps}>{bp.steps.length} étapes · {bp.commands.length} commandes</span>
              </div>
              <div className={styles.bpActions}>
                <button className="btn-ghost" onClick={() => setExpanded(expanded === bp.id ? null : bp.id)}>
                  {expanded === bp.id ? 'Masquer' : 'Voir les étapes'}
                </button>
                <button
                  className={state.blueprintIds.includes(bp.id) ? 'btn-ghost' : 'btn-primary'}
                  onClick={() => toggleBlueprint(bp.id, !state.blueprintIds.includes(bp.id))}
                >
                  {state.blueprintIds.includes(bp.id) ? 'Retirer' : 'Utiliser'}
                </button>
              </div>
            </div>
            <p className={styles.bpDesc}>{bp.description}</p>

            {expanded === bp.id && (
              <div className={styles.stepsPanel}>
                <h4>Étapes</h4>
                <ol className={styles.stepsList}>
                  {bp.steps.map((s, i) => (
                    <li key={i} className={styles.stepItem}>
                      <strong>{s.title}</strong>
                      <p>{s.description}</p>
                    </li>
                  ))}
                </ol>
                <h4>Commandes</h4>
                <ul className={styles.cmdList}>
                  {bp.commands.map(c => (
                    <li key={c.name}>
                      <code>{c.name}</code> — {c.description}
                      <span className={styles.example}>{c.example}</span>
                    </li>
                  ))}
                </ul>
              </div>
            )}
          </div>
        ))}
        {filtered.length === 0 && <p className={styles.empty}>Aucun blueprint trouvé.</p>}
      </div>
    </div>
  );
}
