namespace WinGetDotNet
{
    /// <summary>
    /// Model, used by methods in <see cref="IWinGet"/> interface.
    /// Contains data about how WinGet application process was called, as well as it´s output and it´s exit code.
    /// </summary>
    /// <param name="ProcessCall">
    /// The appearance of a WinGet application process call.
    /// </param>
    /// <param name="ConsoleOutput">
    /// The console output of a WinGet application process call.
    /// </param>
    /// <param name="ExitCode">
    /// The exit code of a WinGet application process call.
    /// </param>
    public sealed record WinGetResult(string ProcessCall, string ConsoleOutput, int ExitCode);
}
