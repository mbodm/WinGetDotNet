namespace WinGetDotNet
{
    public interface IWinGet
    {
        /// <summary>
        /// Verifies if WinGet application is installed.
        /// </summary>
        /// <returns>
        /// A <see cref="bool"/> value, indicating if WinGet is installed on this machine.
        /// </returns>
        bool WinGetIsInstalled { get; }

        /// <summary>
        /// Asynchronously runs WinGet application.
        /// </summary>
        /// <param name="parameters">
        /// The WinGet application parameters, containing
        /// WinGet arguments (like '--version'),
        /// WinGet commands (like 'search'), or
        /// WinGet options (like '--id').
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> to monitor for cancellation requests.
        /// The default value is <see cref="CancellationToken.None"/> here.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> that represents an instance of <see cref="WinGetResult"/>,
        /// containing data about how WinGet was called, as well as it´s output and it´s exit code.
        /// </returns>
        Task<WinGetResult> RunWinGetAsync(string parameters, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="RunWinGetAsync"/>
        /// <param name="timeout">
        /// The amount of time to wait for the WinGet application process, before the process gets canceled.
        /// The default value is 15 seconds, in the default implementation of <see cref="IWinGet"/>.
        /// </param>
        Task<WinGetResult> RunWinGetAsync(string parameters, TimeSpan timeout, CancellationToken cancellationToken = default);
    }
}
