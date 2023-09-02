import {ModuleConfig} from "../../shared/models/module.config";

interface UsuariosConfig extends ModuleConfig {
}

const path = 'usuarios';

export const USUARIOS_CONFIG: UsuariosConfig = {
  name: 'Usuario',
  namePlural: 'Usuarios',
  path,
  pathFront: `/${path}`,
};
