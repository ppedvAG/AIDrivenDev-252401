classDiagram
direction LR

class ProductCatalog {
  name
  validFrom
  validTo
}

class Product {
  name
  description
  availability
}

class Price {
  amount
  currency
}

class ShoppingCart {
  status
  createdAt
  lastUpdatedAt
}

class CartItem {
  quantity
  addedAt
  note
}

class Order {
  orderDate
  status
  totalAmount
}

class OrderLine {
  quantity
  lineAmount
}

class Customer {
  displayName
  email
  deliveryNote
}

ProductCatalog "1" o-- "0..*" Product : lists
Product "1" o-- "1" Price : priced as

Customer "1" --> "0..1" ShoppingCart : owns
ShoppingCart "1" o-- "0..*" CartItem : contains
CartItem "1" --> "1" Product : for

Customer "1" --> "0..*" Order : places
Order "1" o-- "1..*" OrderLine : contains
OrderLine "1" --> "1" Product : for
