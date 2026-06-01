import styles from './CatalogCard.module.css';

interface Props {
  id: string;
  title: string;
  description: string;
  badge?: string;
  selected?: boolean;
  onToggle?: (id: string, selected: boolean) => void;
  actions?: React.ReactNode;
}

export function CatalogCard({ id, title, description, badge, selected, onToggle, actions }: Props) {
  return (
    <div className={`${styles.card} ${selected ? styles.selected : ''}`}>
      <div className={styles.header}>
        <span className={styles.title}>{title}</span>
        {badge && (
          <span className={`badge badge-${badge.toLowerCase()}`}>{badge}</span>
        )}
      </div>
      <p className={styles.description}>{description}</p>
      <div className={styles.footer}>
        {actions}
        {onToggle && (
          <button
            className={selected ? 'btn-ghost' : 'btn-primary'}
            onClick={() => onToggle(id, !selected)}
          >
            {selected ? 'Retirer' : 'Ajouter'}
          </button>
        )}
      </div>
    </div>
  );
}
