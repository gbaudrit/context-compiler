import axios from 'axios';
import type {
  ModuleDto,
  PackDto,
  BlueprintDto,
  ArtifactsIndexDto,
  CompileRequestDto,
  CompileResultDto,
} from '@/types/catalog';

const http = axios.create({ baseURL: '/api' });

export const catalogApi = {
  getModules: (): Promise<ModuleDto[]> =>
    http.get<ModuleDto[]>('/modules').then(r => r.data),

  getPacks: (): Promise<PackDto[]> =>
    http.get<PackDto[]>('/packs').then(r => r.data),

  getBlueprints: (): Promise<BlueprintDto[]> =>
    http.get<BlueprintDto[]>('/blueprints').then(r => r.data),

  getArtifactsIndex: (): Promise<ArtifactsIndexDto> =>
    http.get<ArtifactsIndexDto>('/artifacts/index').then(r => r.data),

  compile: (req: CompileRequestDto): Promise<CompileResultDto> =>
    http.post<CompileResultDto>('/compile', req).then(r => r.data),
};
