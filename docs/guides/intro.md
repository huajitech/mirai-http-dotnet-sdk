# HuajiTech.Mirai.Http

用于开发 mirai 应用基于 [mirai-api-http](https://github.com/project-mirai/mirai-api-http) 的 .NET SDK

项目目前处于测试阶段，不建议用于生产环境

## 示例

1. [复读机示例](http://gitlab.huajitech.net/huajitech/mirai-http-dotnet-sdk/snippets/2)

## 链接

- 文档：https://mirai-http-dotnet-sdk.projects.huajitech.net/
- mirai 项目：https://github.com/mamoe/mirai
- mirai-api-http 项目：https://github.com/project-mirai/mirai-api-http

## 早期访问构建

- (推荐) packages.huajitech.net 上的 [HuajiTech.Mirai.Http](https://packages.huajitech.net/feeds/early-access-nuget/HuajiTech.Mirai.Http/versions)。
- [GitLab CI](https://gitlab.huajitech.net/huajitech/mirai-http-dotnet-sdk/-/pipelines) 的最新 [Pack 产物](https://gitlab.huajitech.net/huajitech/mirai-http-dotnet-sdk/-/jobs/artifacts/master/download?job=pack) / [Build 产物](https://gitlab.huajitech.net/huajitech/mirai-http-dotnet-sdk/-/jobs/artifacts/master/download?job=build)

### 使用 packages.huajitech.net 上的早期访问包

#### 使用 dotnet CLI 和 PackageReference

- 运行以下命令，添加 HuajiTech 早期访问 NuGet 源：

  ```bash
  dotnet nuget add source https://packages.huajitech.net/nuget/early-access-nuget/v3/index.json --name huajitech-early-access
  ```

- 编辑 `.csproj` （或 `.vbproj`、`.fsproj`）文件，并添加一行以指定最新版本的 [HuajiTech.Mirai.Http](https://packages.huajitech.net/feeds/early-access-nuget/HuajiTech.Mirai.Http/versions) 早期访问包。
  例如，`.csproj` 文件可能包含如下所示的 `PackageReference`：

  ```xml
  <PackageReference Include="HuajiTech.Mirai.Http" Version="0.1.0-ci.233" />
  ```

#### 使用程序包管理器控制台

- 在**程序包管理器控制台**中运行以下命令，安装 HuajiTech.Mirai.Http 早期访问包：

  ```powershell
  Install-Package HuajiTech.Mirai.Http -Source https://packages.huajitech.net/nuget/early-access-nuget/v3/index.json
  ```

- 在**程序包管理器控制台**中运行以下命令，更新包：

  ```powershell
  Update-Package HuajiTech.Mirai.Http -Source https://packages.huajitech.net/nuget/early-access-nuget/v3/index.json
  ```


#### 使用 Visual Studio 的 NuGet 包管理器

## 开发环境

### 本项目环境

- Visual Studio 2019
- .NET 5

### 推荐用户环境

- .NET 5
- 控制台应用

## 联系

- Ricky QQ：397050061
- HuajiTech QQ群：[565136444](https://jq.qq.com/?_wv=1027&k=UNTnWwHd)