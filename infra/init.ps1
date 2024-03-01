$hostIp = "127.0.0.1"
$domainsArray = @("auth.local", "postgres.local", "pgadmin.local", "rabbit.local" ) # Add more hostnames as needed
$hostsPath = "C:\Windows\System32\drivers\etc\hosts"

foreach ($domain in $domainsArray) {
    $hostEntry = "$hostIp $domain"
    if (-not (Get-Content $hostsPath | Select-String -Pattern $domain)) {
        $hostEntry | Add-Content -Path $hostsPath
        Write-Host "$domain added to hosts file."
    } else {
        Write-Host "$domain is already in the hosts file."
    }
}
