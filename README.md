# scriban 
## Document
- [Resource](https://github.com/scriban/scriban)
- [Demo online](https://scribanonline.azurewebsites.net)
- [Builtins](https://github.com/scriban/scriban/blob/master/doc/builtins.md)


### Demo
#### Template
```html
  Dear {{ data.name }},

  Your order, {{ data.orderId}}, is now ready to be collected.

  Your order shall be delivered to {{ data.address }}.  If you need it delivered to another location, please contact as ASAP.

  Order: {{ data.orderId}}
  Total: {{ data.total | math.format "c" "en-US" }}

  {{if data.items.size > 1}}
  Items:
  {{else}}
  Item:
  {{end}}
  ------
  {{- for item in data.items }}
   * {{ item.quantity }} x {{ item.name }} - {{ item.total | math.format "c" "en-US" }}
  {{- end }}
  <table>
  {{~ tablerow item in  data.items | array.sort "quantity" -}}
    * {{ item.quantity }} x {{ item.name }} - {{ item.total | math.format "c" "en-US" }}
    {{ end ~}}
  </table>
  Thanks,
  BuyFromUs                                                                
```
#### Data
```json
  {
    "name": "Bob Smith",
    "address": "1 Smith St, Smithville",
    "orderId": "123455",
    "total": 23435.34,
    "items": [
    {
      "name": "1kg carrots",
      "quantity": 1,
      "total": 4.99
    },
    {
      "name": "2L Milk",
      "quantity": 2,
      "total": 3.5
    },
    {
      "name": "2kg carrots",
      "quantity": 1,
      "total": 4.99
    },
    {
      "name": "6kg carrots",
      "quantity": 5,
      "total": 4.99
    }
    ]
  }
```
#### Expected result
```html
  Dear Bob Smith,

  Your order, 123455, is now ready to be collected.

  Your order shall be delivered to 1 Smith St, Smithville.  If you need it delivered to another location, please contact as ASAP.

  Order: 123455
  Total: $23,435.34


  Items:

  ------
   * 1 x 1kg carrots - $4.99
   * 2 x 2L Milk - $3.50
   * 1 x 2kg carrots - $4.99
   * 5 x 6kg carrots - $4.99
  <table>
  <tr class="row1"><td class="col1">* 1 x 1kg carrots - $4.99
    </td></tr>
  <tr class="row2"><td class="col1">* 1 x 2kg carrots - $4.99
    </td></tr>
  <tr class="row3"><td class="col1">* 2 x 2L Milk - $3.50
    </td></tr>
  <tr class="row4"><td class="col1">* 5 x 6kg carrots - $4.99
    </td></tr>
  </table>
  Thanks,
  BuyFromUs      
```
