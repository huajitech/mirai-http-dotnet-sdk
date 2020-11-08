# HuajiTech.Mirai

用于开发 mirai 应用基于 [mirai-api-http](https://github.com/project-mirai/mirai-api-http) 的 .NET SDK

项目目前处于测试阶段，不建议用于生产环境

## 示例

1. [复读机示例](http://gitlab.huajitech.net/huajitech/mirai-http-dotnet-sdk/snippets/2)

## 链接

- GitLab 文档：https://mirai-http-dotnet-sdk.projects.huajitech.net/
- mirai 项目：https://github.com/mamoe/mirai
- mirai-api-http 项目：https://github.com/project-mirai/mirai-api-http

## 早期访问构建

- (推荐) packages.huajitech.net 上的 [HuajiTech.Mirai](https://packages.huajitech.net/feeds/early-access-nuget/HuajiTech.Mirai/versions)。
- [GitLab CI](https://gitlab.huajitech.net/huajitech/mirai-http-dotnet-sdk/-/pipelines) 的 [最新产物](https://gitlab.huajitech.net/huajitech/mirai-http-dotnet-sdk/-/jobs/artifacts/master/download?job=pack)（最新产物不一定可用）

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

### 本项目环境

- Visual Studio 2019
- .NET Core 3.1

### 推荐用户环境

- .NET Core 3.1
- 控制台应用

## 联系

- Ricky QQ：397050061
- HuajiTech QQ群：[565136444](https://jq.qq.com/?_wv=1027&k=UNTnWwHd)

## TODO

### [API](https://github.com/project-mirai/mirai-api-http/blob/master/docs/API.md)

- 图片文件上传
- 注册指令
- 发送指令
- 监听指令
- 获取 Managers

### [事件](https://github.com/project-mirai/mirai-api-http/blob/master/docs/EventType.md)（进度）
- [x] 接收消息
- [x] Bot 登录成功
- [ ] Bot 主动离线 (没想好名称)
- [ ] Bot 被挤下线 (没想好名称)
- [ ] Bot 被服务器断开或因网络问题而掉线 (没想好名称)
- [x] Bot 主动重新登录
- [x] 群消息撤回
- [x] 好友消息撤回
- [x] Bot 在群里的权限被改变
- [ ] Bot 被禁言
- [ ] Bot 被取消禁言
- [ ] Bot 加入了一个新群
- [ ] Bot 主动退出一个群
- [ ] Bot 被踢出一个群
- [ ] 某个群名改变
- [ ] 某群入群公告改变
- [ ] 全员禁言
- [ ] 匿名聊天
- [ ] 坦白说
- [ ] 允许群员邀请好友加群
- [ ] 新人入群的事件
- [ ] 成员被踢出群（该成员不是 Bot）
- [ ] 成员主动离群（该成员不是 Bot）
- [ ] 群名片改动
- [ ] 群头衔改动（只有群主有操作限权）
- [ ] 成员权限改变的事件（该成员不是 Bot）
- [ ] 群成员被禁言事件（该成员不是 Bot）
- [ ] 群成员被取消禁言事件（该成员不是 Bot）
- [ ] 添加好友申请
- [ ] 用户入群申请（Bot 需要有管理员权限）
- [ ] Bot 被邀请入群申请
