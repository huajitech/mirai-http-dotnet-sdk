# HuajiTech.Mirai 简介

用于开发 mirai 应用基于 [mirai-api-http](https://github.com/project-mirai/mirai-api-http) 的 .NET SDK

## 示例

1. [复读机示例](http://gitlab.huajitech.net/huajitech/mirai-http-dotnet-sdk/snippets/2)

## 早期访问构建

- (推荐) packages.huajitech.net 上的 [HuajiTech.Mirai](https://packages.huajitech.net/feeds/early-access-nuget/HuajiTech.Mirai/versions)。
- [GitLab 持续集成](https://gitlab.huajitech.net/huajitech/mirai-http-dotnet-sdk/-/pipelines)的[最新产物](https://gitlab.huajitech.net/huajitech/mirai-http-dotnet-sdk/-/jobs/artifacts/master/download?job=pack)。最新产物不一定可用。

### 使用 packages.huajitech.net 上的早期访问包

#### 使用 dotnet CLI 和 PackageReference

- 运行以下命令，添加 HuajiTech 早期访问 NuGet 源：

  ```bash
  dotnet nuget add source https://packages.huajitech.net/nuget/early-access-nuget/v3/index.json --name huajitech-early-access
  ```

- 编辑 `.csproj` （或 `.vbproj`、`.fsproj`）文件，并添加一行以指定最新版本的 [HuajiTech.Mirai](https://packages.huajitech.net/feeds/early-access-nuget/HuajiTech.Mirai/versions) 早期访问包。
  例如，`.csproj` 文件可能包含如下所示的 `PackageReference`：

  ```xml
  <PackageReference Include="HuajiTech.Mirai" Version="0.1.0-ci.233" />
  ```

#### 使用程序包管理器控制台

- 在**程序包管理器控制台**中运行以下命令，安装 HuajiTech.Mirai 早期访问包：

  ```powershell
  Install-Package HuajiTech.Mirai -Source https://packages.huajitech.net/nuget/early-access-nuget/v3/index.json
  ```

- 在**程序包管理器控制台**中运行以下命令，更新包：

  ```powershell
  Update-Package HuajiTech.Mirai -Source https://packages.huajitech.net/nuget/early-access-nuget/v3/index.json
  ```

## 开发环境

### 本项目

- Visual Studio 2019
- .NET Core 3.1

### 推荐

- .NET Core 3.1
- 控制台应用

## 联系

- Ricky QQ：397050061
- HuajiTech QQ群：[565136444](https://jq.qq.com/?_wv=1027&k=UNTnWwHd)
