@echo off
echo =======================================================
echo DANG DONG GOI UNG DUNG SO CHI TIEU CA NHAN (win-x64)...
echo =======================================================
dotnet publish -c Release -r win-x64 --self-contained false -o ./publish
echo.
echo =======================================================
echo DONG GOI HOAN TAT!
echo Thu muc chua ban chay: .\publish
echo =======================================================
pause
