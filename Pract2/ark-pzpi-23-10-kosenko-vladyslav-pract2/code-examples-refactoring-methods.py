В.1 Приклад оформлення та іменування (Метод Rename Method)

#Добре:

 def calculate_total_price(price: float, quantity: int) -> float:
   """
      Обчислює загальну вартість товару на основі ціни та кількості.
      """
     return price * quantity
 
  def main():
      item_price = 45.5
      item_quantity = 3
     total = calculate_total_price(item_price, item_quantity)
     print(f"Загальна сума: {total}")
 
 if __name__ == '__main__':
     main()

#Погано:

def calc(a,b):
return a*b
def main():
x=45.5; y=3; print('sum=',calc(x,y))
main()

В.2 Приклад декомпозиції та документування (Метод Extract Method)
   def calculate_discount(base_price: float) -> float:
       """
       Визначає суму знижки залежно від обсягу замовлення.
   
       Parameters:
           base_price (float): сума замовлення без знижки.
   
       Returns:
           float: сума нарахованої знижки (5% якщо сума > 1000, інакше 0).
      """
      if base_price > 1000:
          return base_price * 0.05
      return 0.0
  
  def process_order(price: float, quantity: int) -> float:
     """Обробляє замовлення: розраховує базу та віднімає знижку."""
      base_price = price * quantity
      discount = calculate_discount(base_price)
      total_sum = base_price - discount
      return round(total_sum, 2)

  В.3 Приклад спрощення логіки (Метод Simplify Conditional Expression)

  def is_user_active(user) -> bool:
       """
       Перевіряє, чи є користувач валідним та активним.
   
       Рішення: використано логічний оператор 'and' для усунення 
       вкладених умов (піраміди If).
       """
       return user is not None and user.is_active
