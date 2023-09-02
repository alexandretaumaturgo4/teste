import {ModuleConfig} from "../../shared/models/module.config";

interface AuthConfig extends ModuleConfig {
  keyToken: string;
  keyUser: string;
  keyRole: string;
  keyEmail: string;
}

const path = 'auth';

export const AUTH_CONFIG: AuthConfig = {
  name: 'Autenticação',
  namePlural: 'Autenticações',
  path,
  pathFront: `/${path}`,
  keyToken: 'token',
  keyUser: 'user',
  keyRole: 'role',
  keyEmail: 'email'
};
