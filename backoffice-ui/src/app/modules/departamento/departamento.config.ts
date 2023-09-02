import {ModuleConfig} from "../../shared/models/module.config";

interface DepartamentoConfig extends ModuleConfig {
}

const path = 'departamentos';

export const DEPARTAMENTOS_CONFIG: DepartamentoConfig = {
  name: 'Departamento',
  namePlural: 'Departamentos',
  path,
  pathFront: `/${path}`,
};
