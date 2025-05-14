param webAppName string
param location string
param appServicePlanName string
param KC_HOSTNAME string

@secure()
param KC_BOOTSTRAP_ADMIN_PASSWORD string
@secure()
param KC_BOOTSTRAP_ADMIN_USERNAME string
// @secure()
// param KC_DB_URL string
// @secure()
// param KC_DB_USERNAME string
// @secure()
// param KC_DB_PASSWORD string

resource webApp 'Microsoft.Web/sites@2022-09-01' = {
  name: webAppName
  location: location
  kind: 'app,linux,container'
  properties: {
    httpsOnly: true
    reserved: true
    siteConfig: {
      linuxFxVersion: 'DOCKER|keycloak/keycloak'
      alwaysOn: true
      appCommandLine: 'start'
      httpLoggingEnabled: true
      appSettings: [
        {
          name: 'DOCKER_REGISTRY_SERVER_URL'
          value: 'https://index.docker.io/v1'
        }
        {
          name: 'KC_BOOTSTRAP_ADMIN_PASSWORD'
          value: KC_BOOTSTRAP_ADMIN_PASSWORD
        }
        {
          name: 'KC_BOOTSTRAP_ADMIN_USERNAME'
          value: KC_BOOTSTRAP_ADMIN_USERNAME
        }
        {
          name: 'KC_CORS'
          value: 'true'
        }
        {
          name: 'WEBSITES_ENABLE_APP_SERVICE_STORAGE'
          value: 'false'
        }
        // {
        //   name: 'KC_DB'
        //   value: 'mssql'
        // }
        // {
        //   name: 'KC_DB_URL'
        //   value: KC_DB_URL
        // }
        // {
        //   name: 'KC_DB_USERNAME'
        //   value: KC_DB_USERNAME
        // }
        // {
        //   name: 'KC_DB_PASSWORD'
        //   value: KC_DB_PASSWORD
        // }
        {
          name: 'KC_HOSTNAME'
          value: KC_HOSTNAME
        }
        {
          name: 'KC_HOSTNAME_STRICT'
          value: 'false'
        }
        {
          name: 'KC_HOSTNAME_STRICT_HTTPS'
          value: 'false'
        }
        {
          name: 'KC_HTTP_ENABLED'
          value: 'true'
        }
        {
          name: 'KC_PROXY_HEADERS'
          value: 'xforwarded'
        }
      ]
    }
    serverFarmId: resourceId('Microsoft.Web/serverfarms', appServicePlanName)
  }
}
