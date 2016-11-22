# JourneyDiary
##asp.net mvc配合传统事务脚本模式开发架构
### 使用FluentValidation进行数据校验。  
### 使用Autofac进行依赖注入。
### 使用AutoMapper进行模型转换
### 使用Dapper操作数据库
### 使用Miniprofiler进行SQL和页面监控
### 使用Jenkins进行持续集成

##build文件夹说明
### build.bat 为编译脚本，输出路径默认为src同级目录release文件下
### deploy.bat 为自动部署脚本，使用Robocopy将release下的文件复制到远程服务器目录。
