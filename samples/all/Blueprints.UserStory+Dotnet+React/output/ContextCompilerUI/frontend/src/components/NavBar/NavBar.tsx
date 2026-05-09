import { NavLink } from 'react-router-dom';
import styles from './NavBar.module.css';

const links = [
  { to: '/modules',    label: 'Modules' },
  { to: '/packs',      label: 'Packs' },
  { to: '/blueprints', label: 'Blueprints' },
  { to: '/compose',    label: 'Composer' },
  { to: '/preview',    label: 'Prévisualiser' },
];

export function NavBar() {
  return (
    <nav className={styles.nav}>
      <div className={styles.brand}>
        <span className={styles.logo}>⚙</span>
        <span>Context Compiler UI</span>
      </div>
      <ul className={styles.links}>
        {links.map(l => (
          <li key={l.to}>
            <NavLink
              to={l.to}
              className={({ isActive }) => isActive ? `${styles.link} ${styles.active}` : styles.link}
            >
              {l.label}
            </NavLink>
          </li>
        ))}
      </ul>
    </nav>
  );
}
