//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MilkProd
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trade : System.ComponentModel.INotifyPropertyChanged 
    {
     public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = "")
            {
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(name));
            }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trade()
        {
            this.ProductTrade = new System.Collections.ObjectModel.ObservableCollection<ProductTrade>();
        }
    
        
    			private int _id_trade;
    			public int id_trade 
    			{ 
    				get => _id_trade; 
    				set
    				{ 
    					if(_id_trade!=value)
    					{ 
    						_id_trade=value; 
    						OnPropertyChanged("id_trade"); 
    					}
    				}
    			}
        
    			private Nullable<int> _id_worker;
    			public Nullable<int> id_worker 
    			{ 
    				get => _id_worker; 
    				set
    				{ 
    					if(_id_worker!=value)
    					{ 
    						_id_worker=value; 
    						OnPropertyChanged("id_worker"); 
    					}
    				}
    			}
        
    			private Nullable<System.DateTime> _date_trade;
    			public Nullable<System.DateTime> date_trade 
    			{ 
    				get => _date_trade; 
    				set
    				{ 
    					if(_date_trade!=value)
    					{ 
    						_date_trade=value; 
    						OnPropertyChanged("date_trade"); 
    					}
    				}
    			}
        
    			private Nullable<double> _cost_trade;
    			public Nullable<double> cost_trade 
    			{ 
    				get => _cost_trade; 
    				set
    				{ 
    					if(_cost_trade!=value)
    					{ 
    						_cost_trade=value; 
    						OnPropertyChanged("cost_trade"); 
    					}
    				}
    			}
        
    			private Nullable<int> _id_client;
    			public Nullable<int> id_client 
    			{ 
    				get => _id_client; 
    				set
    				{ 
    					if(_id_client!=value)
    					{ 
    						_id_client=value; 
    						OnPropertyChanged("id_client"); 
    					}
    				}
    			}
    
        public virtual Client Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual System.Collections.ObjectModel.ObservableCollection<ProductTrade> ProductTrade { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
