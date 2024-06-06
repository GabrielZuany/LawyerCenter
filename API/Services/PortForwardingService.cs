using Renci.SshNet;
using System;

public class PortForwardingService : IDisposable
{
    private readonly SshClient _sshClient;
    private readonly ForwardedPortLocal _forwardedPort;

    public PortForwardingService(string host, string username, string sshKeyFilePath, string passphrase, string localHost, int localPort, string remoteHost, int remotePort)
    {
        _sshClient = new SshClient(host, username, new PrivateKeyFile(sshKeyFilePath, passphrase));
        _forwardedPort = new ForwardedPortLocal(localHost, (uint)localPort, remoteHost, (uint)remotePort);
    }

    public void StartPortForwarding()
    {   
        _sshClient.Connect();
        if (_sshClient.IsConnected)
        {
            _sshClient.AddForwardedPort(_forwardedPort);
            _forwardedPort.Start();
        }
        else
        {
            throw new InvalidOperationException("Failed to connect to SSH server.");
        }
    }

    public void Dispose()
    {
        _forwardedPort.Stop();
        _sshClient.Disconnect();
        _sshClient.Dispose();
    }
}
