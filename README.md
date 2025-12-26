# CWExpert

CWExpert is a Morse code decoder application that integrates with Morse Runner for amateur radio contest simulation and training.

## Features

- Real-time CW (Morse code) decoding
- Integration with Morse Runner contest simulator
- Multi-channel audio processing
- Configurable audio settings
- Support for various audio interfaces via PortAudio

## System Requirements

### Current Version (x86)
- Windows 10 or later
- .NET Framework 2.0 or later
- Audio interface (sound card)
- 32-bit (x86) architecture

### ARM64 Version (In Development)
- Windows 11 ARM64
- Visual Studio 2026
- x64 or ARM64 native PortAudio library
- See [PORTAUDIO_ARM64_MIGRATION.md](PORTAUDIO_ARM64_MIGRATION.md) for details

## Known Issues

### PortAudio Initialization Failure on ARM64

**Issue**: PA19.Initialize() consistently fails on Windows 11 ARM64 systems.

**Root Cause**: Architecture mismatch
- The included PA19.dll is 32-bit (x86)
- Windows 11 ARM64 has limited/deprecated x86 support
- The application needs x64 or ARM64 PortAudio library

**Solution**: See [PORTAUDIO_ARM64_MIGRATION.md](PORTAUDIO_ARM64_MIGRATION.md) for:
- Detailed diagnosis
- Migration strategies
- Step-by-step implementation guide
- Troubleshooting tips

### Current Status

✅ **Diagnostic Logging Implemented**
- Comprehensive error reporting for PortAudio initialization
- DLL architecture detection
- Detailed debug output for troubleshooting

🔄 **In Progress**
- Migration to x64 platform target
- Obtaining x64 PortAudio library
- Testing on Windows 11 ARM64

⏳ **Planned**
- Native ARM64 build
- Modern .NET Framework upgrade
- Enhanced audio device detection

## Building the Project

### Prerequisites
- Visual Studio 2022 or 2026
- .NET Framework 2.0 SDK (minimum)
- PortAudio library (PA19.dll) matching target architecture

### Build Steps

```bash
# Clone the repository
git clone https://github.com/s56a/CWExpert.git
cd CWExpert

# Open solution in Visual Studio
start CWExpert.sln

# Or build from command line
msbuild CWExpertUR.csproj /p:Configuration=Release /p:Platform=x86
```

### For ARM64 Windows 11

See [PORTAUDIO_ARM64_MIGRATION.md](PORTAUDIO_ARM64_MIGRATION.md) for detailed instructions on:
1. Obtaining x64/ARM64 PortAudio
2. Updating project configuration
3. Building and testing

## Configuration

Audio settings are configured through the Setup dialog:
- Host API selection (MME, DirectSound, WASAPI)
- Input/Output device selection
- Sample rate
- Buffer size
- Latency settings

## Usage

1. Start Morse Runner
2. Launch CWExpert
3. Configure audio settings in Setup
4. Click "Start" to begin decoding
5. Use function keys (F1-F12) to interact with Morse Runner

## Debug Output

The application now provides extensive diagnostic logging. To view:

**In Visual Studio**:
1. Debug → Windows → Output (or Ctrl+Alt+O)
2. Select "Debug" from "Show output from:" dropdown
3. Look for "=== PortAudio" sections

**Using DebugView** (recommended for production):
1. Download from https://learn.microsoft.com/en-us/sysinternals/downloads/debugview
2. Run as Administrator
3. Capture → Capture Global Win32
4. Run CWExpert and review output

## Troubleshooting

### Application Won't Start

Check for these error messages:

**"PA19.dll Missing"**
- Ensure PA19.dll is in the application directory
- Download from project releases or build PortAudio

**"Architecture Mismatch"**
- PA19.dll architecture must match application
- For x86 app: need x86 PA19.dll
- For x64 app: need x64 PA19.dll
- See [PORTAUDIO_ARM64_MIGRATION.md](PORTAUDIO_ARM64_MIGRATION.md)

**"PortAudio Initialization Failed"**
- Check Debug output for specific error code
- Verify audio drivers are installed
- Try different Host API in Setup

### No Audio Devices

1. Check Windows audio settings
2. Ensure drivers are installed
3. Try different Host API (Setup → Audio)
4. Review Debug output for device enumeration

### Poor Performance

1. Increase buffer size in Setup
2. Try WASAPI host API
3. Disable other audio applications
4. Check CPU usage

## Contributing

Contributions welcome! Please:
1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Submit a pull request

## License

GNU General Public License v2.0 or later
See source files for full license text.

## Credits

- Original Author: S56A (YT7PWR)
- PortAudio: http://www.portaudio.com/
- Morse Runner: http://www.dxatlas.com/MorseRunner/

## Contact

For issues related to ARM64 migration or PortAudio problems:
- Check [PORTAUDIO_ARM64_MIGRATION.md](PORTAUDIO_ARM64_MIGRATION.md)
- Review Debug output
- File an issue on GitHub with diagnostics

## Version History

### Current (Development)
- Added comprehensive PortAudio diagnostics
- Enhanced error reporting and logging
- Documented ARM64 migration path
- Improved DLL architecture detection

### Previous
- Basic PortAudio integration
- Morse Runner integration
- Multi-channel CW decoding
