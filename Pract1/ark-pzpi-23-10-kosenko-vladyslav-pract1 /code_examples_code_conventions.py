# Добре:
def calculate_sum(first_number: int, second_number: int) -> int:
    """Повертає суму двох чисел."""
    return first_number + second_number

def main():
    number_a = 5
    number_b = 10
    print(f'Sum = {calculate_sum(number_a, number_b)}')

if __name__ == '__main__':
    main()
  
 # Добре:
# Є докстрінги та зрозумілі імена.
# Дотримано відступи й форматування.
 #Використано f-рядки для виводу.

# Погано:

def calc(x,y):return x+y
def main():
 x=5;y=10;print('sum=',calc(x,y))
main()
# Проблеми:
# Відсутні пробіли навколо операторів.
# Немає відступів і порожніх рядків.
# Незрозумілі імена змінних.
# Код важко читати й підтримувати.
# Немає типізації аргументів.

#Приклад документування програмного коду
def calculate_monthly_payment(principal: float, annual_rate: float,
months: int) -> float:
"""
Обчислює щомісячний платіж за кредитом.

Parameters:
principal (float): сума позики.
annual_rate (float): річна процентна ставка.

months (int): кількість місяців виплат.

Returns:
float: сума щомісячного платежу.
"""
monthly_rate = annual_rate / 12 / 100
payment = principal * (monthly_rate * (1 + monthly_rate) ** months) / ((1 + monthly_rate) ** months - 1)
return round(payment, 2)

