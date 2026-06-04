namespace ContextCompiler.Modules.Abstractions.Pipelines.Prepare;

public enum PreparePipelineModuleKinds
{
    SourceDiscovery = 1000,
    ProjectInventory = 2000,
    ProjectClassification = 3000,
    SkillRecommendation = 4000,
    ConfigurationPlanning = 5000,
    InventoryRendering = 5500,
    ConfigurationRendering = 6000,
    PrepareReport = 7000
}
