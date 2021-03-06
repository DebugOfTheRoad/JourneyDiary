## 项目简介

- asp.net mvc配合传统事务脚本模式开发架构，快速搭建项目。
***

## 相关技术
- 使用FluentValidation进行数据校验。  
- 使用Autofac进行依赖注入。
- 使用AutoMapper进行Model之间的的转换
- 使用Dapper操作数据库
- 使用Miniprofiler进行SQL和页面监控
- 使用Jenkins进行持续集成
- 使用CodeSmith进行代码生成(目前没有开发接口部分的模板)
***

## 项目架构
- JourneyDiary.Web      表现层，处理业务渲染，权限控制等简单业务处理
- JourneyDiary.Services 业务逻辑层
- JourneyDiary.Data     数据库访问层
- JourneyDiary.Core     核心层，包括数据模型，缓存，会话，工具类库等
***

## 持续集成build文件夹说明
- build.bat 为编译脚本，输出路径默认为src同级目录release文件下
- deploy.bat 为自动部署脚本，使用Robocopy将release下的文件复制到远程服务器目录。
