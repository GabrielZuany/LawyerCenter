# Define the SSH command
$sshCommand = "-f", "-N", "-L", "5432:localhost:5432", "-i", "/home/zuany/Desktop/dev/auth/oracle/sudo/ssh-rsa-30-03-2024.key", "ubuntu@168.138.151.184"

# Start SSH tunnel for port 5432
Start-Process -FilePath ssh.exe -ArgumentList $sshCommand -Wait -NoNewWindow

# Start a loop to keep the SSH connection alive
while ($true) {
    # Sleep for an interval (e.g., 60 seconds)
    Start-Sleep -Seconds 60

    # Check if the SSH process is still running
    $process = Get-Process -Name ssh -ErrorAction SilentlyContinue
    if ($process -eq $null) {
        Write-Output "SSH tunnel for port 5432 closed. Restarting..."
        
        # Restart SSH tunnel for port 5432
        Start-Process -FilePath ssh.exe -ArgumentList $sshCommand -Wait -NoNewWindow
    }
}
