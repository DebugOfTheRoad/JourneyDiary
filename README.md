## 项目简介
### asp.net mvc配合传统事务脚本模式开发架构
***
## 相关技术
### 使用FluentValidation进行数据校验。  
### 使用Autofac进行依赖注入。
### 使用AutoMapper进行Model之间的的转换
### 使用Dapper操作数据库
### 使用Miniprofiler进行SQL和页面监控
### 使用Jenkins进行持续集成

***
## 项目架构
### JourneyDiary.Web      表现层，处理业务渲染，权限控制等简单业务处理
### JourneyDiary.Services 业务逻辑层
### JourneyDiary.Manager  通用业务处理层，主要用于缓存，会话保持等通用操作以及对依赖的第三方服务接口封装
### JourneyDiary.Data     数据库访问层
### JourneyDiary.Model    模型层，DTO：Service和Manager向外传输的对象，DataModel: 与数据库表结构一一对应，通过数据库访问层向上传输数据源对象 
### JourneyDiary.Common   公共组件以及工具类库
***
## 持续集成build文件夹说明
### build.bat 为编译脚本，输出路径默认为src同级目录release文件下
### deploy.bat 为自动部署脚本，使用Robocopy将release下的文件复制到远程服务器目录。
### build.msbuild为Jenkins 使用msbuild需要的参数文件,如果使用build.bat脚本进行编译也会用到此文件。
