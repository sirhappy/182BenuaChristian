using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;

namespace dbTask
{
    /// <summary>
    /// Menu tree node.
    /// </summary>
    public class MenuTreeNode
    {
        /// <summary>
        /// Gets the node's parent.
        /// </summary>
        /// <value>The parent.</value>
        public MenuTreeNode Parent { get; }

        /// <summary>
        /// Gets the prompt action.
        /// </summary>
        /// <value>The prompt action.</value>
        public Action OnPromptAction { get; }

        /// <summary>
        /// Gets the decisions.
        /// </summary>
        /// <value>The decisions.</value>
        public IDictionary<int, Func<MenuTreeNode>> Decisions { get; }

        /// <summary>
        /// Gets the node menu.
        /// </summary>
        /// <value>The node menu.</value>
        public string NodeMenu { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:dbTask.MenuTreeNode"/> class.
        /// </summary>
        /// <param name="parent">Parent.</param>
        /// <param name="decisions">Decisions.</param>
        /// <param name="nodeMenu">Node menu.</param>
        /// <param name="onPromptAction">On prompt action.</param>
        public MenuTreeNode(MenuTreeNode parent, IDictionary<int, Func<MenuTreeNode>> decisions, string nodeMenu,
            Action onPromptAction = null)
        {
            Parent = parent;
            NodeMenu = nodeMenu;
            Decisions = decisions;
            OnPromptAction = onPromptAction ?? (() => Console.WriteLine(NodeMenu));
        }
    }

    /// <summary>
    /// Menu tree.
    /// </summary>
    public class MenuTree
    {
        /// <summary>
        /// Gets the root.
        /// </summary>
        /// <value>The root.</value>
        public MenuTreeNode Root { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:dbTask.MenuTree"/> class.
        /// </summary>
        /// <param name="root">Root.</param>
        public MenuTree(MenuTreeNode root)
        {
            Root = root;
        }

        /// <summary>
        /// Begins the tree traversing.
        /// </summary>
        /// <param name="node">Node.</param>
        public void BeginTreeTraversing(MenuTreeNode node)
        {
            node.OnPromptAction();
            if (!(node.Decisions is null))
            {
                int decision = Reader.Read<int>("Enter command", "Smth wrong, reenter",
                    el => node.Decisions.ContainsKey(el));
                BeginTreeTraversing(node.Decisions[decision]?.Invoke() ?? node);
            }
            else
            {
                BeginTreeTraversing(node.Parent);
            }
        }
    }

    /// <summary>
    /// Console manager.
    /// </summary>
    public class ConsoleManager
    {
        /// <summary>
        /// The factory correctness checker.
        /// </summary>
        private IFactoryCorrectnessChecker _checker;

        /// <summary>
        /// The data base.
        /// </summary>
        private readonly IDataBase _dataBase;

        /// <summary>
        /// The requests factory.
        /// </summary>
        private readonly IRequestsFactory _requestsFactory;

        /// <summary>
        /// The data base content checker.
        /// </summary>
        private readonly IDataBaseContentChecker _dataBaseContentChecker;

        /// <summary>
        /// The maximum length of the prefix file name.
        /// </summary>
        private int _maximumPrefixFileNameLen = 14;

        /// <summary>
        /// The back command.
        /// </summary>
        public static string _backCommand = "back";

        /// <summary>
        /// The menu tree.
        /// </summary>
        private MenuTree _menuTree;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:dbTask.ConsoleManager"/> class.
        /// </summary>
        /// <param name="checker">Checker.</param>
        /// <param name="dataBase">Data base.</param>
        /// <param name="requestsFactory">Requests factory.</param>
        /// <param name="dataBaseContentChecker">Data base content checker.</param>
        public ConsoleManager(IFactoryCorrectnessChecker checker, IDataBase dataBase, IRequestsFactory requestsFactory,
            IDataBaseContentChecker dataBaseContentChecker)
        {
            _checker = checker;
            _dataBase = dataBase;
            _requestsFactory = requestsFactory;
            _dataBaseContentChecker = dataBaseContentChecker;
            ConstructTree();
        }

        /// <summary>
        /// Starts the session.
        /// </summary>
        public void StartSession()
        {
            Console.WriteLine("In creating entities, saving file use command \"Back\" to cancel");
            _dataBase.CreateTable<Shop>();
            _dataBase.CreateTable<Order>();
            _dataBase.CreateTable<Customer>();
            _dataBase.CreateTable<Good>();
            _menuTree.BeginTreeTraversing(_menuTree.Root);
        }

        /// <summary>
        /// Constructs the tree.
        /// </summary>
        public void ConstructTree()
        {
            MenuTreeNode createEntitiesNode = null;
            MenuTreeNode saveToJsonNode = null;
            MenuTreeNode requestsNode = null;

            MenuTreeNode createCustomerNode = null;
            MenuTreeNode createShopNode = null;
            MenuTreeNode createOrderNode = null;
            MenuTreeNode createGoodNode = null;

            MenuTreeNode saveOrdersToJson = null;
            MenuTreeNode saveShopsToJson = null;
            MenuTreeNode saveCustomersToJson = null;
            MenuTreeNode saveGoodsToJson = null;
            MenuTreeNode loadFromFilesNode = null;

            MenuTreeNode rootNode = null;

            {
                string nodeMenu = "1.Create Entities\n2.Save To Json\n3.Load From Json\n4. Requests";
                Dictionary<int, Func<MenuTreeNode>> actions = new Dictionary<int, Func<MenuTreeNode>>();
                actions[1] = () => createEntitiesNode;
                actions[2] = () => saveToJsonNode;
                actions[3] = () => loadFromFilesNode;
                actions[4] = () => requestsNode;
                rootNode = new MenuTreeNode(null, actions, nodeMenu, null);
            }

            {
                string nodeMenu =
                    "1.OrdersByCustomerWithLongestName\n2.MostExpensiveGoodCategory\n3.LeastSellsCity\n4.CustomersLastName" +
                    "WhoBoughtMostPopularGood\n5.ShopsAmountInCountryWithLeastAmountOfShops\n6.OrdersInForeignCity\n7.AllOrdersSum\n8.Back";
                Dictionary<int, Func<MenuTreeNode>> actions = new Dictionary<int, Func<MenuTreeNode>>();
                actions[1] = () =>
                {
                    TryCatchWrapper.WrapLinqRequest(() =>
                    {
                        foreach (var lastName in _requestsFactory.GetOrdersByCustomerWithLongestName(_dataBase))
                        {
                            Console.WriteLine(lastName);
                        }
                    });

                    Console.WriteLine();
                    return null;
                };
                actions[2] = () =>
                {
                    TryCatchWrapper.WrapLinqRequest(() =>
                    {
                        var cat = _requestsFactory.GetMostExpensiveGoodCategory(_dataBase);
                        Console.WriteLine(_requestsFactory.GetMostExpensiveGoodCategory(_dataBase) + "\n");
                    });

                    return null;
                };
                actions[3] = () =>
                {
                    TryCatchWrapper.WrapLinqRequest(() =>
                    {
                        Console.WriteLine(_requestsFactory.GetLeastSellsCity(_dataBase));
                    });

                    Console.WriteLine();

                    return null;
                };
                actions[4] = () =>
                {
                    TryCatchWrapper.WrapLinqRequest(() =>
                    {
                        foreach (var lastname in _requestsFactory.GetCustomersLastNameWhoBoughtMostPopularGood(
                            _dataBase))
                        {
                            Console.WriteLine(lastname);
                        }
                    });
                    Console.WriteLine();
                    return null;
                };
                actions[5] = () =>
                {
                    TryCatchWrapper.WrapLinqRequest(() =>
                    {
                        Console.WriteLine(
                            _requestsFactory.GetShopsAmountInCountryWithLeastAmountOfShops(_dataBase));
                    });

                    Console.WriteLine();
                    return null;
                };
                actions[6] = () =>
                {
                    TryCatchWrapper.WrapLinqRequest(() =>
                    {
                        foreach (var order in _requestsFactory.GetOrdersInForeignCity(_dataBase))
                        {
                            Console.WriteLine(order);
                        }
                    });
                    Console.WriteLine();

                    return null;
                };
                actions[7] = () =>
                {
                    TryCatchWrapper.WrapLinqRequest(() =>
                        {
                            Console.WriteLine(_requestsFactory.GetAllOrdersSum(_dataBase).ToString("F3"));
                        }
                    );
                    return null;
                };
                actions[8] = () => { return rootNode; };
                requestsNode = new MenuTreeNode(rootNode, actions, nodeMenu, null);
            }

            {
                string nodeMenu = "1.Create Order\n2.Create Shop\n3.Create Good\n4.Create Customer\n5.Back";
                Dictionary<int, Func<MenuTreeNode>> actions = new Dictionary<int, Func<MenuTreeNode>>();
                actions[1] = () => createOrderNode;
                actions[2] = () => createShopNode;
                actions[3] = () => createGoodNode;
                actions[4] = () => createCustomerNode;
                actions[5] = () => rootNode;
                createEntitiesNode = new MenuTreeNode(rootNode, actions, nodeMenu, null);
            }
            {
                string nodeMenu = OrderFactory.ConsolePrompt;
                Action action = () =>
                {
                    TryCatchWrapper.WrapInsertIntoDbRequest(() =>
                    {
                        Console.WriteLine(nodeMenu);
                        OrderFactory factory = null;
                        string entered = null;
                        while (!(OrderFactory.TryParse(entered = Console.ReadLine(), out factory) &&
                                 _checker.IsValid<OrderFactory, Order>(factory)))
                        {
                            if (entered?.ToLower() == _backCommand)
                            {
                                return;
                            }

                            Console.WriteLine("Something went wrong, reenter pls");
                            Console.WriteLine("Bad format, too big names");
                            Console.WriteLine("Make sure following shop, customer and good exists");
                        }

                        _dataBase.InsertInto<Order>(factory);
                    });
                };
                createOrderNode = new MenuTreeNode(createEntitiesNode, null, nodeMenu, action);
            }

            {
                string nodeMenu = ShopFactory.ConsolePrompt;
                Action action = () =>
                {
                    TryCatchWrapper.WrapInsertIntoDbRequest(() =>
                    {
                        Console.WriteLine(nodeMenu);

                        ShopFactory factory = null;
                        string entered = null;
                        while (!(ShopFactory.TryParse(entered = Console.ReadLine(), out factory) &&
                                 _checker.IsValid<ShopFactory, Shop>(factory)))
                        {
                            if (entered?.ToLower() == _backCommand)
                            {
                                return;
                            }

                            Console.WriteLine("Something went wrong, reenter pls");
                            Console.WriteLine("Bad format, too big names");
                        }

                        _dataBase.InsertInto<Shop>(factory);
                    });
                };
                createShopNode = new MenuTreeNode(createEntitiesNode, null, nodeMenu, action);
            }

            {
                string nodeMenu = CustomerFactory.ConsolePrompt;
                Action action = () =>
                {
                    TryCatchWrapper.WrapInsertIntoDbRequest(() =>
                    {
                        Console.WriteLine(nodeMenu);

                        CustomerFactory factory = null;
                        string entered = null;
                        while (!(CustomerFactory.TryParse(entered = Console.ReadLine(), out factory) &&
                                 _checker.IsValid<CustomerFactory, Customer>(factory)))
                        {
                            if (entered?.ToLower() == _backCommand)
                            {
                                return;
                            }

                            Console.WriteLine("Something went wrong, reenter pls");
                            Console.WriteLine("Bad format, too big names");
                        }

                        _dataBase.InsertInto<Customer>(factory);
                    });
                };
                createCustomerNode = new MenuTreeNode(createEntitiesNode, null, nodeMenu, action);
            }

            {
                string nodeMenu = GoodFactory.ConsolePrompt;
                Action action = () =>
                {
                    TryCatchWrapper.WrapInsertIntoDbRequest(() =>
                    {
                        Console.WriteLine(nodeMenu);

                        GoodFactory factory = null;
                        string entered = null;
                        while (!(GoodFactory.TryParse(entered = Console.ReadLine(), out factory) &&
                                 _checker.IsValid<GoodFactory, Good>(factory)))
                        {
                            if (entered?.ToLower() == _backCommand)
                            {
                                return;
                            }

                            Console.WriteLine("Something went wrong, reenter pls");
                            Console.WriteLine("Bad format, too big names");
                        }

                        _dataBase.InsertInto<Good>(factory);
                    });
                };
                createGoodNode = new MenuTreeNode(createEntitiesNode, null, nodeMenu, action);
            }

            {
                string nodeMenu = "1. Save Orders\n2. Save Shops\n3. Save Customers\n4. Save Goods\n5. Back";
                Dictionary<int, Func<MenuTreeNode>> dictionary = new Dictionary<int, Func<MenuTreeNode>>();
                dictionary[1] = () => saveOrdersToJson;
                dictionary[2] = () => saveShopsToJson;
                dictionary[3] = () => saveCustomersToJson;
                dictionary[4] = () => saveGoodsToJson;
                dictionary[5] = () => rootNode;

                saveToJsonNode = new MenuTreeNode(rootNode, dictionary, nodeMenu);
            }

            {
                string nodeMenu = "Enter fileName prefix. File will be save as DBOrder{prefix}.json";
                Action action = () =>
                {
                    TryCatchWrapper.WrapSerializationRequest(() =>
                    {
                        Console.WriteLine(nodeMenu);

                        string prefix = null;
                        while (!((prefix = Console.ReadLine()).Length <= _maximumPrefixFileNameLen))
                        {
                            if (prefix?.ToLower() == _backCommand)
                            {
                                return;
                            }

                            Console.WriteLine("Too big prefix");
                        }

                        _dataBase.Serialize<Order>(prefix);
                    });
                };
                saveOrdersToJson = new MenuTreeNode(saveToJsonNode, null, nodeMenu, action);
            }

            {
                string nodeMenu = "Enter fileName prefix. File will be save as DBShop{prefix}.json";
                Action action = () =>
                {
                    TryCatchWrapper.WrapSerializationRequest(() =>
                    {
                        Console.WriteLine(nodeMenu);

                        string prefix = null;
                        while (!((prefix = Console.ReadLine()).Length <= _maximumPrefixFileNameLen))
                        {
                            if (prefix?.ToLower() == _backCommand)
                            {
                                return;
                            }

                            Console.WriteLine("Too big prefix");
                        }

                        _dataBase.Serialize<Shop>(prefix);
                    });
                };
                saveShopsToJson = new MenuTreeNode(saveToJsonNode, null, nodeMenu, action);
            }

            {
                string nodeMenu = "Enter fileName prefix. File will be save as DBCustomer{prefix}.json";
                Action action = () =>
                {
                    TryCatchWrapper.WrapSerializationRequest(() =>
                    {
                        Console.WriteLine(nodeMenu);

                        string prefix = null;
                        while (!((prefix = Console.ReadLine()).Length <= _maximumPrefixFileNameLen))
                        {
                            if (prefix?.ToLower() == _backCommand)
                            {
                                return;
                            }

                            Console.WriteLine("Too big prefix");
                        }

                        _dataBase.Serialize<Customer>(prefix);
                    });
                };
                saveCustomersToJson = new MenuTreeNode(saveToJsonNode, null, nodeMenu, action);
            }

            {
                string nodeMenu = "Enter fileName prefix. File will be save as DBGood{prefix}.json";
                Action action = () =>
                {
                    TryCatchWrapper.WrapSerializationRequest(() =>
                    {
                        Console.WriteLine(nodeMenu);

                        string prefix = null;
                        while (!((prefix = Console.ReadLine()).Length <= _maximumPrefixFileNameLen))
                        {
                            if (prefix?.ToLower() == _backCommand)
                            {
                                return;
                            }

                            Console.WriteLine("Too big prefix");
                        }

                        _dataBase.Serialize<Good>(prefix);
                    });
                };
                saveGoodsToJson = new MenuTreeNode(saveToJsonNode, null, nodeMenu, action);
            }

            {
                string nodeMenu = "Enter 4 files: {Customers}.json;{Shops}.json;{Orders}.json;{Goods}.json";

                void Action()
                {
                    Console.WriteLine(nodeMenu);
                    var line = Console.ReadLine();
                    var input = line?.Split(new[] {';'}).AsEnumerable() ?? new List<string>();
                    if (line == _backCommand)
                    {
                        return;
                    }

                    input = input.Select(el => el.Trim());

                    if (input.Count() != 4)
                    {
                        Console.WriteLine("Wrong format");
                        return;
                    }

                    if (input.Any(el =>
                    {
                        var splitted = el.Split(new char[] {'.'});
                        if (splitted.Length <= 1)
                        {
                            return true;
                        }

                        if (splitted.Last() != "json")
                        {
                            return true;
                        }

                        return false;
                    }))
                    {
                        Console.WriteLine("Wrong format");
                    }

                    TryCatchWrapper.WrapDeserializationRequest(() =>
                    {
                        var _prevVersion = (DataBase) _dataBase.Clone();
                        _dataBase.RestoreDataTable<Customer>("", input.ElementAt(0));
                        _dataBase.RestoreDataTable<Shop>("", input.ElementAt(1));
                        _dataBase.RestoreDataTable<Order>("", input.ElementAt(2));
                        _dataBase.RestoreDataTable<Good>("", input.ElementAt(3));

                        if (!_dataBaseContentChecker.IsValid(_dataBase))
                        {
                            Console.WriteLine("Database content is invalid, continue(y/n)");
                            string choice = Console.ReadLine().Trim();
                            if (choice == "n")
                            {
                                _dataBase.RollBack(_prevVersion);
                            }
                        }
                    });
                }

                loadFromFilesNode = new MenuTreeNode(rootNode, null, nodeMenu, Action);
            }
            _menuTree = new MenuTree(rootNode);
        }
    }
}