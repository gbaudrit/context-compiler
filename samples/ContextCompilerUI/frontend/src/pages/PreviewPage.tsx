import { useState } from 'react';
import ReactMarkdown from 'react-markdown';
import { useCompose } from '@/context/ComposeContext';
import styles from './PreviewPage.module.css';

export function PreviewPage() {
  const { state } = useCompose();
  const [copied, setCopied] = useState(false);
  const [tab, setTab] = useState<'rendered' | 'raw' | 'artifacts'>('rendered');

  const result = state.compileResult;

  if (!result) {
    return (
      <div className={styles.empty}>
        <p>Aucun contexte compilé.</p>
        <p className={styles.hint}>Composez et compilez d'abord depuis l'onglet <strong>Composer</strong>.</p>
      </div>
    );
  }

  async function handleCopy() {
    await navigator.clipboard.writeText(result.promptContext);
    setCopied(true);
    setTimeout(() => setCopied(false), 3000);
  }

  function handleDownload() {
    const blob = new Blob([result.promptContext], { type: 'text/markdown' });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = 'prompt.context.md';
    a.click();
    URL.revokeObjectURL(url);
  }

  return (
    <div className={styles.page}>
      <div className={styles.header}>
        <h1 className={styles.heading}>Prévisualisation</h1>
        <div className={styles.actions}>
          <button className="btn-ghost" onClick={handleCopy}>
            {copied ? '✓ Copié !' : 'Copier'}
          </button>
          <button className="btn-primary" onClick={handleDownload}>
            Télécharger
          </button>
        </div>
      </div>

      <div className={styles.tabs}>
        {(['rendered', 'raw', 'artifacts'] as const).map(t => (
          <button
            key={t}
            className={`${styles.tab} ${tab === t ? styles.activeTab : ''}`}
            onClick={() => setTab(t)}
          >
            {t === 'rendered' ? 'Rendu' : t === 'raw' ? 'Brut' : 'Artefacts'}
          </button>
        ))}
      </div>

      {tab === 'rendered' && (
        <div className={styles.rendered}>
          <ReactMarkdown>{result.promptContext}</ReactMarkdown>
        </div>
      )}

      {tab === 'raw' && (
        <pre className={styles.raw}>{result.promptContext}</pre>
      )}

      {tab === 'artifacts' && (
        <table className={styles.table}>
          <thead>
            <tr>
              <th>Fichier</th>
              <th>Type</th>
              <th>Taille</th>
              <th>Généré par</th>
            </tr>
          </thead>
          <tbody>
            {result.artifactsIndex.artifacts.map(a => (
              <tr key={a.filename}>
                <td><code>{a.filename}</code></td>
                <td>{a.mimeType}</td>
                <td>{a.size} octets</td>
                <td className={styles.muted}>{a.generatedBy}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
