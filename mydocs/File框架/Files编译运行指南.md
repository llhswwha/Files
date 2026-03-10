# Files 文件管理器 - 编译与运行指南

本文档提供详细的开发环境配置、编译和运行步骤说明。

---

## 📋 目录

- [系统要求](#-系统要求)
- [必需的开发环境和框架](#-必需的开发环境和框架)
- [环境搭建步骤](#-环境搭建步骤)
- [手动编译项目](#-手动编译项目)
- [运行项目](#-运行项目)
- [常见问题解决](#-常见问题解决)

---

## 💻 系统要求

### 操作系统
- **Windows 10 版本 19041.0** 或更高版本（最低支持版本）
- **Windows 11**（推荐）
- 支持架构：x86、x64、ARM64

### 硬件要求
- **CPU**: 1 GHz 或更快的处理器
- **内存**: 至少 4 GB RAM（推荐 8 GB）
- **磁盘空间**: 至少 10 GB 可用空间
- **显示器分辨率**: 1280 x 720 或更高

---

## 🔧 必需的开发环境和框架

### 1. Visual Studio 2022（推荐）或 Visual Studio 2026

**⚠️ 重要提示**: 
- **Visual Studio 2022 版本 17.14 或更高版本** 才能支持 .NET 10.0
- 如果您的 VS 2022 版本低于 17.14，会收到错误："不支持在 Visual Studio 中以 .NET 10.0 或更高版本为目标"
- **推荐升级到 Visual Studio 2026**（最佳 .NET 10 支持）

**版本要求**: 
- ✅ **最低**: Visual Studio 2022 版本 17.14+
- ✅ **推荐**: Visual Studio 2026（完全支持 .NET 10）

**检查您的 Visual Studio 版本**:
1. 打开 Visual Studio
2. 点击 `帮助` → `关于 Microsoft Visual Studio`
3. 查看版本号（例如：17.14.x 或更高）

**升级 Visual Studio 2022 到最新版本**:
1. 打开 **Visual Studio Installer**
2. 点击 Visual Studio 2022 旁边的 `更新` 按钮
3. 等待更新完成

**下载 Visual Studio 2026**（推荐）:
- [Visual Studio 2026 下载页面](https://visualstudio.microsoft.com/zh-hans/downloads/)
- 选择适合的版本（Community/Professional/Enterprise）

**需要安装的工作负载**:
- ✅ **.NET 桌面开发**
- ✅ **通用 Windows 平台开发**
- ✅ **Windows App SDK 工具和工作负载**

**安装步骤**:
1. 下载并安装 [Visual Studio 2022 Community/Professional/Enterprise](https://visualstudio.microsoft.com/zh-hans/downloads/)
2. 运行 Visual Studio Installer
3. 选择以下工作负载：
   - `.NET 桌面开发`
   - `通用 Windows 平台开发`
4. 在右侧"安装详细信息"中，确保勾选：
   - `Windows App SDK 工具`
   - `.NET 10.0 SDK`（或最新版本）
   - `Windows 10 SDK (10.0.26100.0)` 或更高版本
5. 点击"修改"开始安装

### 2. .NET SDK

**版本**: .NET 10.0 SDK (10.0.102 或更高)

项目使用 `global.json` 指定 SDK 版本：
```json
{
  "sdk": {
    "version": "10.0.102",
    "rollForward": "latestMajor"
  }
}
```

**下载地址**: [.NET 10.0 SDK](https://dotnet.microsoft.com/zh-cn/download/dotnet/10.0)

**⚠️ 重要提示**: 
- 即使安装了 Visual Studio，也建议单独安装最新的 .NET 10 SDK
- .NET SDK 独立于 Visual Studio，可以手动更新
- 如果 VS 2022 版本较旧，安装最新 .NET SDK 后可能仍会收到警告，但可以正常编译

**验证安装**:
```powershell
# 在 PowerShell 中运行
dotnet --version
# 应显示 10.0.x 或更高版本
```

> ⚠️ **注意**: Visual Studio 2022 可能已包含 .NET SDK，但建议检查版本是否符合要求。如果版本不匹配，优先从官网下载最新的 .NET 10 SDK。

### 3. Windows App SDK

**版本**: Windows App SDK 1.8 或更高

Windows App SDK 通常随 Visual Studio 2022 的"通用 Windows 平台开发"工作负载一起安装。

**验证安装**:
```powershell
# 在 PowerShell 中运行
Get-AppxPackage -Name Microsoft.WindowsAppSDK
```

### 4. Windows SDK

**版本**: Windows 10 SDK 26100 或更高（推荐）
**最低版本**: Windows 10 SDK 19041

**获取方式**:
- 通过 Visual Studio Installer 安装
- 或单独下载：[Windows 10 SDK](https://developer.microsoft.com/zh-cn/windows/downloads/windows-sdk/)

### 5. MSBuild

MSBuild 已包含在 Visual Studio 中，用于命令行构建。

**验证安装**:
```powershell
msbuild -version
```

### 6. NuGet

NuGet 包管理器已集成到 Visual Studio 和 .NET CLI 中。

### 7. Git for Windows

**用途**: 克隆源代码仓库

**下载地址**: [Git for Windows](https://git-scm.com/download/win)

---

## 🛠️ 环境搭建步骤

### 步骤 1: 克隆项目仓库

```powershell
# 打开 PowerShell 或命令提示符
cd D:\GitHubProjects

# 如果尚未克隆项目
git clone https://github.com/files-community/Files.git

# 进入项目目录
cd Files
```

### 步骤 2: 安装 .NET 全局工具（可选）

```powershell
# 安装 XAML 格式化工具（代码规范所需）
dotnet tool install --global XamlStyler.Console
```

### 步骤 3: 还原 NuGet 包

```powershell
# 方法 1: 使用 dotnet CLI
dotnet restore Files.slnx

# 方法 2: 使用 MSBuild
msbuild Files.slnx -t:Restore
```

### 步骤 4: 安装 WinAppDriver（用于 UI 测试，可选）

如果需要运行自动化 UI 测试：

1. 下载 [WinAppDriver v1.2.1](https://github.com/microsoft/WinAppDriver/releases)
2. 运行安装程序
3. 安装后，在运行测试前需要启动 WinAppDriver

---

## 🔨 手动编译项目

### 方法一：使用 Visual Studio（推荐）

#### 1. 打开解决方案

1. 启动 **Visual Studio 2022**
2. 选择 `文件` → `打开` → `项目/解决方案`
3. 导航到项目根目录
4. 选择 `Files.slnx` 文件并打开

#### 2. 配置解决方案

在 Visual Studio 中：

1. **选择配置**: 
   - 工具栏下拉框选择 `Debug` 或 `Release`
   - Debug: 包含调试符号，便于开发和调试
   - Release: 优化编译，用于发布

2. **选择平台**:
   - x64（推荐，适用于大多数现代 PC）
   - x86（32 位系统）
   - ARM64（ARM 架构设备）

#### 3. 设置启动项目

1. 在"解决方案资源管理器"中右键点击 `Files.App` 项目
2. 选择 `设为启动项目`

#### 4. 生成解决方案

```
菜单路径: 生成 → 生成解决方案
快捷键: Ctrl + Shift + B
```

或者只生成 Files.App 项目：
```
右键 Files.App → 生成
```

#### 5. 查看输出

生成成功后，可在以下位置找到编译产物：
```
src\Files.App\bin\<Platform>\<Configuration>\net10.0-windows10.0.26100.0\
```

例如：
```
src\Files.App\bin\x64\Debug\net10.0-windows10.0.26100.0\
```

---

### 方法二：使用命令行（高级用户）

#### 1. 还原依赖包

```powershell
# 切换到项目根目录
cd D:\GitHubProjects\Files

# 还原所有 NuGet 包
dotnet restore Files.slnx
```

#### 2. 编译项目

**编译整个解决方案**:
```powershell
# Debug 模式 (x64)
dotnet build Files.slnx -c Debug -p:Platform=x64

# Release 模式 (x64)
dotnet build Files.slnx -c Release -p:Platform=x64
```

**只编译 Files.App 主项目**:
```powershell
# Debug 模式
dotnet build src\Files.App\Files.App.csproj -c Debug -p:Platform=x64

# Release 模式
dotnet build src\Files.App\Files.App.csproj -c Release -p:Platform=x64
```

#### 3. 使用 MSBuild 编译（传统方式）

```powershell
# 还原
msbuild Files.slnx -t:Restore -p:Platform=x64 -p:Configuration=Debug

# 编译（不打包）
msbuild src\Files.App\Files.App.csproj `
  -t:Build `
  -p:Configuration=Debug `
  -p:Platform=x64 `
  -p:AppxBundle=Never `
  -p:GenerateAppxPackageOnBuild=false
```

#### 4. 创建 MSIX 安装包（可选）

如需创建可分发的 MSIX 包：

```powershell
# 首先需要生成自签名证书
.\.github\scripts\Generate-SelfCertPfx.ps1 -Destination "FilesApp_SelfSigned.pfx"

# 打包（以 x64 Release 为例）
msbuild src\Files.App\Files.App.csproj `
  -t:Build `
  -p:Configuration=Release `
  -p:Platform=x64 `
  -p:AppxBundlePlatforms=x64 `
  -p:AppxBundle=Always `
  -p:GenerateAppxPackageOnBuild=true `
  -p:AppxPackageDir=AppxPackages\ `
  -p:UapAppxPackageBuildMode=SideloadOnly `
  -p:AppxPackageSigningEnabled=true `
  -p:PackageCertificateKeyFile=FilesApp_SelfSigned.pfx
```

打包完成后，MSIX 文件位于：
```
src\Files.App\AppxPackages\
```

---

## ▶️ 运行项目

### 方法一：从 Visual Studio 运行（调试模式）

1. 确保 `Files.App` 已设为启动项目
2. 按 `F5` 或点击 `本地 Windows 调试器` 按钮
3. 应用将启动并进入调试模式

**优点**:
- 可以设置断点调试
- 实时查看变量和调用栈
- 输出窗口显示日志

### 方法二：直接运行编译产物

编译成功后，直接运行可执行文件：

```powershell
# 路径示例（根据实际情况调整）
cd D:\GitHubProjects\Files\src\Files.App\bin\x64\Debug\net10.0-windows10.0.26100.0

# 运行程序
.\Files.exe
```

### 方法三：使用 PowerShell 启动

```powershell
# 完整路径运行
& "D:\GitHubProjects\Files\src\Files.App\bin\x64\Debug\net10.0-windows10.0.26100.0\Files.exe"
```

### 方法四：部署 MSIX 包（如果已打包）

1. 右键点击生成的 `.msixbundle` 文件
2. 选择 `安装`
3. 安装完成后，从开始菜单启动 Files

或使用 PowerShell 安装：
```powershell
Add-AppxPackage -Path .\Files.App_1.0.0.0_x64.msixbundle
```

---

## ❓ 常见问题解决

### 问题 1: Visual Studio 不支持 .NET 10.0

**错误信息**:
```
不支持在 Visual Studio 2022 17.14 中以 .NET 10.0 或更高版本为目标。
```

**原因**: 
- Visual Studio 2022 版本低于 17.14，无法完全支持 .NET 10
- 或者未正确安装 .NET 10 SDK

**解决方案**:

**方案 A - 升级 Visual Studio 2022（推荐）**:
1. 打开 **Visual Studio Installer**
2. 点击 Visual Studio 2022 旁边的 `更新` 按钮
3. 如果有可用更新，等待下载安装完成
4. 重新启动 Visual Studio

**方案 B - 手动安装 .NET 10 SDK**:
1. 访问 [.NET 10 下载页面](https://dotnet.microsoft.com/zh-cn/download/dotnet/10.0)
2. 下载并安装 **.NET 10 SDK** (x64 或 ARM64，根据您的系统)
3. 重启计算机（重要！）
4. 重新打开 Visual Studio

**方案 C - 升级到 Visual Studio 2026（最佳方案）**:
1. 下载 [Visual Studio 2026](https://visualstudio.microsoft.com/zh-hans/downloads/)
2. 安装时选择相同的工作负载：
   - `.NET 桌面开发`
   - `通用 Windows 平台开发`
3. 完成后用 VS 2026 打开项目

**验证修复**:
```powershell
# 检查 .NET SDK 版本
dotnet --version
# 应显示 10.0.x

# 在 Visual Studio 中检查
# 右键项目 → 属性 → 目标框架，应能看到 .NET 10.0 选项
```

---

### 问题 2: 找不到 .NET SDK

**错误信息**:
```
error NETSDK1045: The current .NET SDK does not support targeting .NET 10.0.
```

**解决方案**:
1. 确认已安装 .NET 10.0 SDK
2. 检查 `global.json` 中的版本要求
3. 运行 `dotnet --version` 验证安装的版本
4. 如未安装，从官网下载并安装

### 问题 2: 缺少 Windows SDK

**错误信息**:
```
error MSB8036: The Windows SDK version 10.0.26100.0 was not found.
```

**解决方案**:
1. 打开 Visual Studio Installer
2. 点击"修改"
3. 勾选"Windows 10 SDK (10.0.26100.0)"或更高版本
4. 点击"修改"开始安装

### 问题 3: 无法加载 Windows App SDK

**错误信息**:
```
error : The current .NET SDK does not have the Windows Desktop SDK required.
```

**解决方案**:
1. 打开 Visual Studio Installer
2. 修改安装
3. 确保勾选 `.NET 桌面开发` 工作负载
4. 在右侧勾选 `Windows App SDK 工具`

### 问题 4: NuGet 包还原失败

**错误信息**:
```
error NU1101: Unable to find package xxx
```

**解决方案**:
```powershell
# 清除 NuGet 缓存
dotnet nuget locals all --clear

# 重新还原
dotnet restore Files.slnx --force

# 如果使用代理，可能需要配置 NuGet.config
```

### 问题 5: 编译时出现 CsWin32 错误

**错误信息**:
```
error CS0518: Predefined type 'System.Runtime.InteropServices.LibraryImportAttribute' is not defined or imported
```

**解决方案**:
1. 关闭 Visual Studio
2. 删除 `bin` 和 `obj` 文件夹
3. 重新打开 Visual Studio
4. 重新生成解决方案

### 问题 6: 应用启动失败 - 找不到运行时

**错误信息**:
```
Missing Runtime Error
```

**解决方案**:
这通常是因为缺少 Windows App SDK 运行时。尝试：

1. 安装最新的 Windows App SDK 运行时：
   - 下载：[Windows App SDK Runtime](https://aka.ms/windowsappsdk/latest)
   
2. 或者在项目中包含运行时（自包含部署）：
   ```xml
   <!-- 在 Files.App.csproj 中修改 -->
   <SelfContained>true</SelfContained>
   <WindowsAppSDKSelfContained>true</WindowsAppSDKSelfContained>
   ```

### 问题 7: 权限不足无法注册应用

**错误信息**:
```
error DEP0700: Registration of the app failed.
```

**解决方案**:
1. 以管理员身份运行 Visual Studio
2. 或者启用"开发者模式":
   - 设置 → 更新和安全 → 针对开发人员
   - 启用"开发者模式"

### 问题 8: 编译缓慢或内存不足

**优化建议**:
```powershell
# 限制并行构建数量
dotnet build -m:2

# 只编译当前项目而非整个解决方案
dotnet build src\Files.App\Files.App.csproj

# 使用 Release 模式（更快但无调试符号）
dotnet build -c Release
```

---

## 📝 快速参考命令

### 一键编译（PowerShell 脚本）

创建 `build.ps1` 脚本：

```powershell
# build.ps1
param(
    [string]$Configuration = "Debug",
    [string]$Platform = "x64"
)

Write-Host "=== Files 项目编译脚本 ===" -ForegroundColor Green
Write-Host "配置：$Configuration" -ForegroundColor Cyan
Write-Host "平台：$Platform" -ForegroundColor Cyan

# 还原 NuGet 包
Write-Host "`n[1/3] 还原 NuGet 包..." -ForegroundColor Yellow
dotnet restore Files.slnx

# 编译项目
Write-Host "`n[2/3] 编译项目..." -ForegroundColor Yellow
dotnet build src\Files.App\Files.App.csproj `
    -c $Configuration `
    -p:Platform=$Platform `
    -p:AppxBundle=Never `
    -p:GenerateAppxPackageOnBuild=false

# 完成
if ($LASTEXITCODE -eq 0) {
    Write-Host "`n✅ 编译成功!" -ForegroundColor Green
    $outputPath = "src\Files.App\bin\$Platform\$Configuration\net10.0-windows10.0.26100.0"
    Write-Host "输出路径：$outputPath" -ForegroundColor Cyan
} else {
    Write-Host "`n❌ 编译失败!" -ForegroundColor Red
    exit 1
}
```

使用方法：
```powershell
# Debug 模式
.\build.ps1 -Configuration Debug -Platform x64

# Release 模式
.\build.ps1 -Configuration Release -Platform x64
```

### 清理构建产物

```powershell
# 删除所有 bin 和 obj 文件夹
Get-ChildItem -Recurse -Include "bin","obj" | Remove-Item -Recurse -Force

# 或使用 dotnet 命令
dotnet clean Files.slnx
```

---

## 🔗 相关资源链接

- [官方文档](https://files.community/docs/contributing/building-from-source)
- [Windows App SDK 文档](https://docs.microsoft.com/zh-cn/windows/apps/windows-app-sdk/)
- [.NET 10 文档](https://docs.microsoft.com/zh-cn/dotnet/core/whats-new/dotnet-10)
- [WinUI 3 文档](https://docs.microsoft.com/zh-cn/windows/apps/winui/winui3/)
- [项目 GitHub Issues](https://github.com/files-community/Files/issues)
- [Discord 社区](https://discord.gg/files)

---

## 📞 获取帮助

如果遇到文档中未涵盖的问题：

1. **查看现有 Issues**: [GitHub Issues](https://github.com/files-community/Files/issues)
2. **提交新 Issue**: 描述详细错误信息和复现步骤
3. **社区支持**: 加入 Discord 社区寻求实时帮助
4. **查阅 Wiki**: 项目 Wiki 可能有更多技术细节

---

**最后更新**: 2026 年 03 月 09 日  
**适用版本**: Files 开发版本（基于 .NET 10.0 + WinUI 3）
