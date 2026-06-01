import { useGraphStore } from '../stores/graphStore';

export const Header = () => {
  const { rawData, nodes, filteredNodeIds } = useGraphStore();

  const totalPipelines = rawData?.pipelines.length || 0;
  const totalStages = rawData?.stages.length || 0;
  const totalSteps = rawData?.steps.length || 0;
  const totalNodes = nodes.length;

  const visibleNodes = filteredNodeIds ? filteredNodeIds.size : totalNodes;

  return (
    <header style={{
      background: 'linear-gradient(135deg, #667eea 0%, #764ba2 100%)',
      color: 'white',
      padding: '15px 20px',
      boxShadow: '0 2px 4px rgba(0,0,0,0.1)'
    }}>
      <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
        <div>
          <h1 style={{ margin: 0, fontSize: '24px', fontWeight: 'bold' }}>
            Pipeline Visualization
          </h1>
          <p style={{ margin: '5px 0 0 0', fontSize: '13px', opacity: 0.9 }}>
            Interactive pipeline execution graph powered by React Flow & ELK
          </p>
        </div>

        <div style={{ display: 'flex', gap: '20px' }}>
          <div style={{ textAlign: 'center' }}>
            <div style={{ fontSize: '24px', fontWeight: 'bold' }}>{totalPipelines}</div>
            <div style={{ fontSize: '11px', opacity: 0.8 }}>Pipelines</div>
          </div>
          <div style={{ textAlign: 'center' }}>
            <div style={{ fontSize: '24px', fontWeight: 'bold' }}>{totalStages}</div>
            <div style={{ fontSize: '11px', opacity: 0.8 }}>Stages</div>
          </div>
          <div style={{ textAlign: 'center' }}>
            <div style={{ fontSize: '24px', fontWeight: 'bold' }}>{totalSteps}</div>
            <div style={{ fontSize: '11px', opacity: 0.8 }}>Steps</div>
          </div>
          <div style={{ textAlign: 'center' }}>
            <div style={{ fontSize: '24px', fontWeight: 'bold' }}>
              {visibleNodes} / {totalNodes}
            </div>
            <div style={{ fontSize: '11px', opacity: 0.8 }}>Visible Nodes</div>
          </div>
        </div>
      </div>
    </header>
  );
};
