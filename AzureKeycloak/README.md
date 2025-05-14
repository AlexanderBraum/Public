# AzureKeycloak
This repo contains the files to set up a Keycloak instance as an Azure container App Service.

## Files
- Infra/KeycloakAzure.bicep: Infrastructure file declaring how to roll out the Keycloak instance in Azure. 
- Infra/KeycloakAzure.bicepparam: File containing the settings to use when rolling out the Keycloak infrastructure. Please note that the variables need to be set. The variables 'KC_BOOTSTRAP_ADMIN_USERNAME' and 'KC_BOOTSTRAP_ADMIN_PASSWORD' will be overwritten in the pipeline file. This is implemented this way so GitHub secrets can be used.
- workflows/pipeline-infra-keycloak.yml: The pipeline file. This can be used for a GitHub Action. Please note that it is required to set the 'env:' variables.