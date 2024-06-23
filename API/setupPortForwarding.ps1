# Forward Port 5432
Start-Process -FilePath ssh.exe -ArgumentList "-f", "-N", "-L", "5432:localhost:5432", "-i", "/home/zuany/Desktop/dev/auth/oracle/sudo/ssh-rsa-30-03-2024.key", "ubuntu@168.138.151.184" -Wait -NoNewWindow

# Forward Port 5001
Start-Process -FilePath ssh.exe -ArgumentList "-f", "-N", "-L", "5001:localhost:5001", "-i", "/home/zuany/Desktop/dev/auth/oracle/sudo/ssh-rsa-30-03-2024.key", "ubuntu@168.138.151.184" -Wait -NoNewWindow
