## Creating an Azure App Service

### 1. Go to the Azure Portal
- Navigate to the [Azure Portal](https://portal.azure.com/).

### 2. Create a New App Service
- Search for **App Services** in the search bar and click **Create**.
- Fill in the required details:
  - **Subscription**: Select your Azure subscription.
  - **Resource Group**: Create a new resource group or use an existing one.
  - **Name**: Enter a unique name for your App Service.
  - **Runtime Stack**: Select `.NET 9`.
  - **Region**: Choose a region close to your users.
- Click **Review + Create**, then **Create**.

### 3. Download the Publish Profile
- After the App Service is created, go to the **Overview** tab.
- Click **Get Publish Profile** to download the `publishsettings` file.
- Save this file securely, as it will be used for deployment.

## Configuring GitHub Workflow for Deployment

### 1. Add the Publish Profile to GitHub Secrets
- Go to your GitHub repository.
- Navigate to **Settings** > **Secrets and Variables** > **Actions**.
- Click **New Repository Secret**.
- Add a secret with the name `AZURE_WEBAPP_PUBLISH_PROFILE` and paste the contents of the `publishsettings` file.

### 2. Update Your GitHub Workflow
  ```yaml
  ...
  - name: Deploy to Azure Web App
    uses: azure/webapps-deploy@v3
    with:
      app-name: YourAppServiceName
      publish-profile: ${{ secrets.AZURE_WEBAPP_PUBLISH_PROFILE }}
      package: ./publish
  ...
  ```

## Connecting Azure SQL to Azure App Service

## Prerequisites
- An Azure SQL Server with a database.
- An Azure App Service.
- Access to the Azure Portal.

## Steps

### 1. Enable Managed Identity for App Service
- Go to your App Service in the Azure Portal.
- Under **Settings**, click **Identity**.
- Enable the **System-assigned managed identity** and save the changes.

### 2. Grant Permissions to Managed Identity
- Go to your Azure SQL Server in the Azure Portal.
- Assign the Managed Identity as a user in the database:
  ```sql
  CREATE USER [YourAppServiceName] FROM EXTERNAL PROVIDER;
  ALTER ROLE db_datareader ADD MEMBER [YourAppServiceName];
  ALTER ROLE db_datawriter ADD MEMBER [YourAppServiceName];
  ```

### 3. Configure the Connection String
- Add the following connection string to your App Service's **appsettings.json**:
  ```
  Server=yourserver.database.windows.net;Database=yourdb;Authentication=Active Directory Default;
  ```

## Troubleshooting
- **Connection Timeout**: Ensure the App Service's outbound IPs are allowed in the SQL Server firewall.
- **Authentication Errors**: Verify that the Managed Identity has been granted the correct roles.