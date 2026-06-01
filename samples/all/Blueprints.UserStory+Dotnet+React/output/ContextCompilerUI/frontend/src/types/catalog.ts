// Domain types matching backend DTOs

export interface ModuleDto {
  id: string;
  name: string;
  description: string;
  category: string;
  nuGetPackage: string;
  pipelinePhase: string;
}

export interface PackDto {
  id: string;
  name: string;
  description: string;
  moduleIds: string[];
}

export interface BlueprintStepDto {
  title: string;
  description: string;
}

export interface BlueprintCommandDto {
  name: string;
  description: string;
  example: string;
}

export interface BlueprintDto {
  id: string;
  name: string;
  description: string;
  steps: BlueprintStepDto[];
  commands: BlueprintCommandDto[];
  packIds: string[];
}

export interface ArtifactDto {
  filename: string;
  description: string;
  mimeType: string;
  size: number;
  generatedBy: string;
}

export interface ArtifactsIndexDto {
  artifacts: ArtifactDto[];
}

export interface CompileRequestDto {
  moduleIds: string[];
  packIds: string[];
  blueprintIds: string[];
  options?: Record<string, string>;
}

export interface CompileResultDto {
  promptContext: string;
  artifactsIndex: ArtifactsIndexDto;
  success: boolean;
  errorMessage?: string;
}
