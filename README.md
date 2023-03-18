# ВАЖНО

## Для запуска проекта нужно удалить папку миграций и в диспетчере пакетов прописать

EntityFrameworkCore\Add-Migration MyMigration -context AppDBContext

а затем

EntityFrameworkCore\Update-Database -context AppDBContext

После этого все заработает

## PS первого пользователя для входа в приложение нужно создавать вручную через таблицу Users (используя Обозреватель объектов SQL Server)
