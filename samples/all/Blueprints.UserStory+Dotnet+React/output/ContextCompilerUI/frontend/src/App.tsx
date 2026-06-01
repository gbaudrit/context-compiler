import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import { NavBar } from '@/components/NavBar/NavBar';
import { ComposeProvider } from '@/context/ComposeContext';
import { ModulesPage, PacksPage, BlueprintsPage } from '@/pages/CatalogPages';
import { ComposePage } from '@/pages/ComposePage';
import { PreviewPage } from '@/pages/PreviewPage';

export default function App() {
  return (
    <BrowserRouter>
      <ComposeProvider>
        <NavBar />
        <Routes>
          <Route path="/" element={<Navigate to="/blueprints" replace />} />
          <Route path="/modules"    element={<ModulesPage />} />
          <Route path="/packs"      element={<PacksPage />} />
          <Route path="/blueprints" element={<BlueprintsPage />} />
          <Route path="/compose"    element={<ComposePage />} />
          <Route path="/preview"    element={<PreviewPage />} />
          <Route path="*"           element={<Navigate to="/blueprints" replace />} />
        </Routes>
      </ComposeProvider>
    </BrowserRouter>
  );
}
