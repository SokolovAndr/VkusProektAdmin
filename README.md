# ВАЖНО

## Для запуска проекта нужно удалить папку миграций и в диспетчере пакетов прописать

EntityFrameworkCore\Add-Migration MyMigration -context AppDBContext
EntityFrameworkCore\Update-Database -context AppDBContext

После этого все заработает
