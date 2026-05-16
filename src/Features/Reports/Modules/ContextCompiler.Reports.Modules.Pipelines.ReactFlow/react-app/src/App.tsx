import { useEffect, useState } from 'react';
import { ReactFlowProvider } from 'reactflow';
import { Header } from './components/Header';
import { PipelineGraph } from './components/PipelineGraph';
import { Sidebar } from './components/Sidebar';
import { useGraphStore } from './stores/graphStore';
import type { GraphData } from './types';

function App() {
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const { loadData } = useGraphStore();

  useEffect(() => {
    // Load data from window.PIPELINE_DATA (injected by .NET module)
    try {
      const data = window.PIPELINE_DATA;

      if (!data) {
        setError('No pipeline data found. The data should be injected by the .NET module.');
        setIsLoading(false);
        return;
      }

      // Validate data structure
      if (!data.pipelines || !data.stages || !data.steps || !data.edges) {
        setError('Invalid pipeline data structure.');
        setIsLoading(false);
        return;
      }

      loadData(data as GraphData);
      setIsLoading(false);
    } catch (err) {
      console.error('Failed to load pipeline data:', err);
      setError('Failed to load pipeline data: ' + (err as Error).message);
      setIsLoading(false);
    }
  }, [loadData]);

  if (isLoading) {
    return (
      <div style={{
        width: '100vw',
        height: '100vh',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        background: '#f5f5f5'
      }}>
        <div style={{ textAlign: 'center' }}>
          <div style={{ fontSize: '48px', marginBottom: '20px' }}>⏳</div>
          <h2>Loading Pipeline Data...</h2>
          <p style={{ color: '#6b7280' }}>Please wait while we prepare the visualization</p>
        </div>
      </div>
    );
  }

  if (error) {
    return (
      <div style={{
        width: '100vw',
        height: '100vh',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        background: '#f5f5f5'
      }}>
        <div style={{
          textAlign: 'center',
          maxWidth: '600px',
          padding: '30px',
          background: 'white',
          borderRadius: '8px',
          boxShadow: '0 4px 6px rgba(0,0,0,0.1)'
        }}>
          <div style={{ fontSize: '48px', marginBottom: '20px' }}>⚠️</div>
          <h2 style={{ color: '#ef4444' }}>Error Loading Data</h2>
          <p style={{ color: '#6b7280', marginTop: '15px' }}>{error}</p>
          <div style={{
            marginTop: '20px',
            padding: '15px',
            background: '#f3f4f6',
            borderRadius: '4px',
            textAlign: 'left'
          }}>
            <strong>Troubleshooting:</strong>
            <ul style={{ marginTop: '10px', paddingLeft: '20px' }}>
              <li>Ensure the .NET module is correctly injecting the data</li>
              <li>Check the browser console for more details</li>
              <li>Verify that window.PIPELINE_DATA is defined</li>
            </ul>
          </div>
        </div>
      </div>
    );
  }

  return (
    <ReactFlowProvider>
      <div style={{
        width: '100vw',
        height: '100vh',
        display: 'flex',
        flexDirection: 'column',
        overflow: 'hidden'
      }}>
        <Header />
        <div style={{
          flex: 1,
          display: 'flex',
          overflow: 'hidden'
        }}>
          <div style={{ flex: 1 }}>
            <PipelineGraph />
          </div>
          <Sidebar />
        </div>
      </div>
    </ReactFlowProvider>
  );
}

export default App;
