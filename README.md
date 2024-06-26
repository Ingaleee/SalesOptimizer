# Консольное приложение и ASP.NET сервис для расчета продаж

## Описание задания

Разработать консольное приложение и ASP.NET сервис для расчета среднедневных продаж, прогнозирования продаж на заданное количество дней и определения потребности в закупке товаров. Приложение должно принимать команды от пользователя и возвращать рассчитанные значения.

### Требования

- Консольное приложение и ASP.NET сервис должны быть структурированы, с разделением на уровни представления, бизнес-логики и доступа к данным.
- Обработка ошибок.
- Данные для расчетов должны считываться из текстовых файлов.

### Примеры команд

- Расчет среднедневных продаж: `ads 123`
- Прогнозирование продаж: `prediction 456 45`
- Расчет потребности в закупке: `demand 678 14`

## Подготовительные материалы

- История продаж товаров (не менее 10 товаров, история продаж за 30 дней).
- Коэффициенты сезонности.

## Структура приложения

1. **Чтение данных**
   - Функции для чтения истории продаж и коэффициентов сезонности из файлов.
2. **Обработка команд**
   - Функция для анализа введенной команды и вызова соответствующей логики расчета.
3. **Расчет среднедневных продаж**
   - Функция для расчета среднего количества продаж товара за день.
4. **Прогнозирование продаж**
   - Функция для прогнозирования будущих продаж на основе истории и коэффициентов сезонности.
5. **Расчет потребности в закупке**
   - Функция для определения, сколько товара нужно заказать, чтобы удовлетворить прогнозируемую потребность.

## Реализация

- Разработка функций для чтения данных из файлов.
- Создание логики обработки команд пользователя.
- Реализация алгоритмов расчета среднедневных продаж, прогнозирования и расчета потребности в закупке.
- Обработка ошибок и исключений.
- Разработка ASP.NET сервиса с аналогичной функциональностью.
