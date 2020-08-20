# HuajiTech.CoolQ

用于开发 mirai 应用基于 mirai-http-api 的 .NET SDK

## 示例

1. [复读机示例](http://gitlab.huajitech.net/huajitech/mirai-http-dotnet-sdk/snippets/2)

## 本项目开发环境

- Visual Studio 2019
- .NET Core 3.1

## 推荐开发配置

- .NET Core 3.1
- 控制台应用

## 联系

- Ricky QQ：397050061
- HuajiTech QQ群：[565136444](https://jq.qq.com/?_wv=1027&k=UNTnWwHd)

## TODO

### SDK

- 使用数据交互类以改用 Json 反序列化
- 完善 Session 的 Dispose

### API

- [图片文件上传](https://github.com/project-mirai/mirai-api-http/#%E5%9B%BE%E7%89%87%E6%96%87%E4%BB%B6%E4%B8%8A%E4%BC%A0)
- [群设置](https://github.com/project-mirai/mirai-api-http/#%E7%BE%A4%E8%AE%BE%E7%BD%AE)
- [修改群员资料](https://github.com/project-mirai/mirai-api-http/#%E4%BF%AE%E6%94%B9%E7%BE%A4%E5%91%98%E8%B5%84%E6%96%99)
- [注册指令](https://github.com/project-mirai/mirai-api-http/#%E6%B3%A8%E5%86%8C%E6%8C%87%E4%BB%A4)
- [发送指令](https://github.com/project-mirai/mirai-api-http/#%E5%8F%91%E9%80%81%E6%8C%87%E4%BB%A4)
- [监听指令](https://github.com/project-mirai/mirai-api-http/#%E7%9B%91%E5%90%AC%E6%8C%87%E4%BB%A4)
- [获取 Managers](https://github.com/project-mirai/mirai-api-http/#%E8%8E%B7%E5%8F%96mangers)

### [事件](https://github.com/project-mirai/mirai-api-http/blob/master/EventType.md)（进度）
- [x] 接收消息
- [x] Bot 登录成功
- [ ] Bot 主动离线 (没想好名称)
- [ ] Bot 被挤下线 (没想好名称)
- [ ] Bot 被服务器断开或因网络问题而掉线 (没想好名称)
- [x] Bot 主动重新登录
- [ ] 群消息撤回
- [ ] 好友消息撤回
- [ ] Bot 在群里的权限被改变
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