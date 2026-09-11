# Called from reg.bat (already elevated). Adds bindingRedirects that any COM host
# (1C, PowerShell, VBA, etc.) needs, because those hosts do NOT read
# SkkmConnector.dll.config - only the machine-wide machine.config is consulted for them.
#
# - System.Text.Json: reference assembly used at compile time is stamped 8.0.0.0,
#   but the runtime/GAC assembly is 8.0.0.5 -> redirect 0.0.0.0-8.0.0.5 -> 8.0.0.5.
# - System.Runtime.CompilerServices.Unsafe: System.Memory references it at 4.0.4.1,
#   but only 6.0.0.0 is installed in the GAC -> redirect 0.0.0.0-6.0.0.0 -> 6.0.0.0.

$paths = @(
    "$env:WINDIR\Microsoft.NET\Framework\v4.0.30319\Config\machine.config",
    "$env:WINDIR\Microsoft.NET\Framework64\v4.0.30319\Config\machine.config"
)

$redirects = @(
    @{ Name = "System.Text.Json"; Token = "cc7b13ffcd2ddd51"; OldVersion = "0.0.0.0-8.0.0.5"; NewVersion = "8.0.0.5" },
    @{ Name = "System.Runtime.CompilerServices.Unsafe"; Token = "b03f5f7f11d50a3a"; OldVersion = "0.0.0.0-6.0.0.0"; NewVersion = "6.0.0.0" }
)

foreach ($path in $paths) {
    Write-Host "=== $path ==="

    if (-not (Test-Path $path)) {
        Write-Host "  FILE NOT FOUND, skipping"
        continue
    }

    $content = Get-Content -Path $path -Raw
    $changed = $false

    foreach ($r in $redirects) {
        if ($content -match [regex]::Escape("<assemblyIdentity name=`"$($r.Name)`"")) {
            Write-Host "  Redirect for $($r.Name) already present, skipping"
            continue
        }

        if ($content -notmatch '<assemblyBinding[^>]*>') {
            Write-Host "  No <assemblyBinding> section found for $($r.Name) - edit manually"
            continue
        }

        $entry = @"
            <dependentAssembly>
                <assemblyIdentity name="$($r.Name)" publicKeyToken="$($r.Token)" culture="neutral" />
                <bindingRedirect oldVersion="$($r.OldVersion)" newVersion="$($r.NewVersion)" />
            </dependentAssembly>
"@
        $content = $content -replace '(<assemblyBinding[^>]*>)', "`$1`r`n$entry"
        $changed = $true
        Write-Host "  Added redirect for $($r.Name)"
    }

    if ($changed) {
        $backup = "$path.bak_$(Get-Date -Format yyyyMMdd_HHmmss)"
        Copy-Item -Path $path -Destination $backup -Force
        Set-Content -Path $path -Value $content -Encoding UTF8 -NoNewline
        Write-Host "  Updated OK (backup: $backup)"
    }
}
