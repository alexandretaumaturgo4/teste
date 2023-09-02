import {ModuleConfig} from "../../shared/models/module.config";

interface AuthConfig extends ModuleConfig {
  keyToken: string;
  keyUser: string;
}

const path = 'pessoas';

export const PESSOAS_CONFIG: AuthConfig = {
  name: 'Pessoa',
  namePlural: 'Pessoas',
  path,
  pathFront: `/${path}`,
  keyToken: 'token',
  keyUser: 'user'
};
