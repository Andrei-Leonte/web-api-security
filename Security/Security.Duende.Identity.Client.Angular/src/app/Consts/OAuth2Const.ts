import { AuthConfig } from 'angular-oauth2-oidc';

export const authCodeFlowConfig: AuthConfig = {
  issuer: 'https://localhost:2101',

  redirectUri: "https://localhost:4200/signin-oidc",

  clientId: 'web',

  dummyClientSecret: 'secret',
  requireHttps: false,
  
  responseType: 'code',

  scope: 'openid api1 profile offline_access',
  requestAccessToken: true,
  showDebugInformation: true,
  silentRefreshShowIFrame: true,
  tokenEndpoint: 'https://localhost:2101/connect/token'
};
