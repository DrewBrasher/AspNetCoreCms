
## I am no longer working on this project.  I've decided to use and contribute to [OrchardCore](https://github.com/OrchardCMS/OrchardCore) instead of building my own CMS.

# AspNetCoreCms
Open Source Content Management System (CMS) Built in ASP.NET Core
### ~~This project is in the very early stages of development.  Suggestions and contributions are welcome.~~
 
## Goals
- Make this a Visual Studio template for starting a new CMS site.
- Also build it in a way that it could easily be integrated into an existing site instead of starting a new site.
 
## Current state of master branch.
Functional for two content types (Carousel and Article) that are displayed in set areas of the page.  Carousels are at the top and articles can be either full width or in bootstrap columns col-md-4.
See the projects tab for features that are planned or currently being built.
 
## Getting started
1. Clone this Repository.
2. Open in Visual Studio 2017.
3. (optional) Change the connection string "cms" in appsettings.json to use the MsSql database you want (if you leave this as is it will create a database in (localdb)\\mssqllocaldb).
4. Open NuGet Package Manager Console (Tools > Nuget Package Manager > Package Manager Console) and run: 
 
   `Update-Database`
5. Run the Project.
6. Click "Register" in the top right corner and create a new user.  the first user you create will be a Site Admin and can add and edit content.
 
## Adding a page
To add a new page, just navigate to the Url you want to create.  If you are signed in as a Site Admin you will have the option to create the page.
 
## Adding Content
If you visit a page while logged in as a Site Admin you will see buttons to add new content.  When you click to add the content it will be created with some default text.  You can click the text to edit it.  Changes are saved on blur.
 
## Multitenancy
Thanks to ([SaasKit](https://github.com/saaskit/saaskit/wiki/SaasKit-Multitenancy)), AspNetCoreCms now supports multiple domains with one code base.  To manage your sites:

1. Log in as a Site Admin
2. Go to {yoururl}/Cms/ManageSites
3. Add or edit you domain names
4. If you don't want to use the default theme, you can add themes by adding more layout cshtml files to the Views/Shared/ folder with this naming convention: _Layout_{yourthemename}.
