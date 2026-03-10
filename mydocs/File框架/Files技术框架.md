我来分析这个项目的技术框架。让我先查看一些关键文件来了解项目的整体架构。


现在让我查看更多关键文件来深入了解技术架构：


让我再查看一些核心服务文件来完善分析：


现在让我查看一下自定义控件和 MVVM 架构：


基于我对项目的深入分析，现在我可以为您提供完整的技术框架分析报告:

## 📊 Files 项目技术框架分析

### 🎯 **项目概述**
Files 是一个现代化的 **Windows 文件管理器**，采用最新的 Microsoft 技术栈构建，支持 x86、x64 和 ARM64 架构。

---

### 🏗️ **核心技术栈**

#### **1. 基础框架**
- **.NET 10.0** (最新版本)
- **Windows App SDK 1.8** (WinUI 3)
- **Windows 10 SDK 26100** (最低支持版本 19041)
- **C# 预览版语言特性**

#### **2. UI 框架**
- **WinUI 3** - 现代 Windows UI 框架
- **XAML** - 声明式 UI 设计
- **自定义控件库** (`Files.App.Controls`)
  - 侧边栏 (Sidebar)
  - 工具栏 (Toolbar)
  - 面包屑导航 (BreadcrumbBar)
  - 网格分割器 (GridSplitter)
  - 自适应网格视图 (AdaptiveGridView)
  - 超级搜索框 (Omnibar)

---

### 📦 **架构模式**

#### **MVVM 架构**
使用 **CommunityToolkit.Mvvm** 实现完整的 MVVM 模式：

```
ViewModels/
├── MainPageViewModel.cs      # 主页面视图模型
├── ShellViewModel.cs         # Shell 视图模型
├── HomeViewModel.cs          # 主页视图模型
├── Settings/                 # 设置相关 VM
├── Dialogs/                  # 对话框相关 VM
└── Properties/               # 属性面板 VM
```

**关键特性：**
- `ObservableObject` - 可观察对象基类
- `RelayCommand` / `IAsyncRelayCommand` - 命令绑定
- `WeakReferenceMessenger` - 弱引用消息传递
- 依赖注入容器配置

---

### 🔧 **项目结构**

#### **核心项目**

| 项目名称 | 类型 | 说明 |
|---------|------|------|
| **Files.App** | WinUI 应用 | 主应用程序 |
| **Files.Core.Storage** | .NET Standard | 核心存储抽象层 |
| **Files.Shared** | .NET Standard | 共享工具和扩展 |
| **Files.App.Controls** | WinUI 控件 | 自定义 UI 控件库 |
| **Files.App.CsWin32** | C#/Win32 P/Invoke | Windows API 互操作 |
| **Files.App.Storage** | .NET | 存储实现 (FTP/本地) |
| **Files.App.Server** | .NET | 进程外 COM 服务器 |
| **Files.App.BackgroundTasks** | .NET | 后台任务处理 |
| **Files.Core.SourceGenerator** | Roslyn | 源代码生成器 |

#### **测试项目**
- `Files.App.UITests` - UI 自动化测试 (Appium)
- `Files.InteractionTests` - 交互测试

---

### 📚 **关键 NuGet 包**

#### **UI 组件**
```xml
<PackageReference Include="Microsoft.WindowsAppSDK" Version="1.8.260209005" />
<PackageReference Include="Microsoft.Graphics.Win2D" Version="1.3.2" />
<PackageReference Include="CommunityToolkit.WinUI.*" Version="8.2.251219" />
<PackageReference Include="WinUIEx" Version="2.5.1" />
<PackageReference Include="ColorCode.WinUI" Version="2.0.15" />
```

#### **MVVM & DI**
```xml
<PackageReference Include="CommunityToolkit.Mvvm" Version="8.4.0" />
<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="10.0.2" />
<PackageReference Include="Microsoft.Extensions.Hosting" Version="10.0.2" />
<PackageReference Include="Microsoft.Extensions.Logging" Version="10.0.2" />
```

#### **功能库**
```xml
<!-- 压缩/解压 -->
<PackageReference Include="SevenZipSharp" Version="1.0.2" />
<PackageReference Include="SharpZipLib" Version="1.4.2" />

<!-- FTP -->
<PackageReference Include="FluentFTP" Version="53.0.2" />

<!-- Git -->
<PackageReference Include="LibGit2Sharp" Version="0.30.0" />

<!-- 数据库 -->
<PackageReference Include="SQLitePCLRaw.bundle_green" Version="2.1.11" />
<PackageReference Include="Microsoft.Data.Sqlite.Core" Version="10.0.2" />

<!-- 媒体标签 -->
<PackageReference Include="TagLibSharp" Version="2.3.0" />

<!-- 错误追踪 -->
<PackageReference Include="Sentry" Version="6.0.0" />
```

---

### 🎨 **UI 特性**

#### **主题系统**
- ✅ 浅色主题 (Light)
- ✅ 深色主题 (Dark)
- ✅ 高对比度主题 (HighContrast)
- ✅ Mica 材质效果
- ✅ 自定义颜色资源字典

#### **布局系统**
```
Views/
├── MainWindow.xaml           # 主窗口
├── HomePage.xaml            # 主页
├── MainNavigationPage.xaml  # 导航页
├── Layouts/                 # 布局视图
│   ├── DetailsLayoutPage.xaml    # 详细信息视图
│   ├── TilesLayoutPage.xaml      # 磁贴视图
│   ├── GridViewPage.xaml         # 网格视图
│   └── ColumnsLayoutPage.xaml    # 列视图
└── Properties/              # 属性面板
```

---

### ⚙️ **服务层架构**

#### **核心服务接口**

```csharp
Services/
├── IAppService.cs                    # 应用服务
├── IUserSettingsService.cs           # 用户设置服务
├── IFileTagsService.cs               # 文件标签服务
├── IQuickAccessService.cs            # 快速访问服务
├── IStorageService.cs                # 存储服务
├── IFtpStorageService.cs             # FTP 存储服务
├── IPreviewPopupService.cs           # 预览弹出服务
├── IDateTimeFormatterService.cs      # 日期时间格式化服务
└── ISizeProviderService.cs           # 大小计算服务
```

#### **设置管理**
```csharp
Settings/
├── GeneralSettingsService       # 通用设置
├── AppearanceSettingsService    # 外观设置
├── FolderSettingsService        # 文件夹设置
├── AdvancedSettingsService      # 高级设置
└── ... (共 11 个设置服务)
```

---

### 🔌 **Windows API 集成**

#### **CsWin32 P/Invoke**
使用 `Microsoft.Windows.CsWin32` 自动生成 Win32 API 绑定：

```csharp
// 示例 API 调用
Windows.Win32.PInvoke.MessageBox(...)
Vanara.Windows.Shell.*     // Shell 操作
Vanara.Windows.Extensions  // Windows 扩展
```

#### **COM 互操作**
- 自定义文件对话框 (`Files.App.OpenDialog` / `SaveDialog`)
- 进程外 COM 服务器 (`Files.App.Server`)
- WinRT 组件交互

---

### 🛠️ **开发工具链**

#### **构建配置**
```json
global.json:
{
  "sdk": { "version": "10.0.102", "rollForward": "latestMajor" },
  "test": { "runner": "Microsoft.Testing.Platform" }
}
```

#### **中央包管理**
使用 `Directory.Packages.props` 集中管理所有 NuGet 包版本

#### **源生成器**
- `Files.Core.SourceGenerator` - 自定义代码生成
- `CommunityToolkit.Labs.WinUI.DependencyPropertyGenerator` - 依赖属性生成
- `Microsoft.CodeAnalysis.CSharp` - Roslyn 编译器 API

---

### 📋 **数据模型**

```csharp
Data/
├── Items/          # 数据项模型
│   ├── ListedItem.cs           # 列表项
│   ├── DriveItem.cs            # 驱动器项
│   ├── LocationItem.cs         # 位置项
│   └── ... (44 个文件)
├── Models/         # 业务模型
├── Enums/          # 枚举定义 (54 个)
├── Contracts/      # 数据契约 (49 个)
└── Messages/       # 消息契约
```

---

### 🌐 **国际化**

支持 **50+ 种语言**,包括:
- 英语 (en-US, en-GB)
- 中文简体/繁体 (zh-Hans, zh-Hant)
- 日语 (ja-JP)
- 韩语 (ko-KR)
- 德语 (de-DE)
- 法语 (fr-FR)
- 西班牙语 (es-ES, es-419)
- 等...

使用 `.resw` 资源文件和 `Strings/en-US/Resources.resw`

---

### 🔐 **安全特性**

- ✅ 启用可空引用类型 (`Nullable=enable`)
- ✅ AOT 兼容 (`IsAotCompatible=true`)
- ✅ 裁剪优化 (`IsTrimmable=true`)
- ✅ ReadyToRun 预编译 (Release 模式)
- ✅ SHA256 签名
- ✅ MSIX 打包部署

---

### 📊 **总结**

这是一个**企业级现代化 Windows 应用**,采用了:
- ✅ 最新的 .NET 10 + WinUI 3 技术栈
- ✅ 完整的 MVVM 架构和依赖注入
- ✅ 模块化设计和清晰的关注点分离
- ✅ 丰富的第三方库集成
- ✅ 完善的测试和本地化支持
- ✅ 专业的 Windows API 深度集成

**适用场景**: 高性能文件管理、系统工具开发、现代 Windows 桌面应用