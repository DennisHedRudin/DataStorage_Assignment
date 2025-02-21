import React, { useState, useEffect } from "react";
import { createProject, getCustomers, getProducts, getUsers, getStatuses } from "../services/projectService"; // Lägg till funktioner för att hämta data
import { useNavigate } from "react-router-dom";

const CreateProjectPage = () => {
    const [title, setTitle] = useState("");
    const [startDate, setStartDate] = useState("");
    const [endDate, setEndDate] = useState("");
    const [description, setDescription] = useState("");
    const [customers, setCustomers] = useState([]);
    const [products, setProducts] = useState([]);
    const [users, setUsers] = useState([]);    
    const [statuses, setStatuses] = useState([]);  
    const [selectedCustomer, setSelectedCustomer] = useState("");
    const [selectedProduct, setSelectedProduct] = useState("");
    const [selectedUser, setSelectedUser] = useState("");
    const [selectedStatus, setSelectedStatus] = useState("");  
    const navigate = useNavigate();


  useEffect(() => {
    const fetchData = async () => {
      try {
        const customerData = await getCustomers();
        const productData = await getProducts();
        const userData = await getUsers();
        const statusData = await getStatuses();

        setCustomers(customerData);
        setProducts(productData);
        setUsers(userData);
        setStatuses(statusData); 
      } catch (error) {
        console.error("Error fetching data", error);
      }
    };

    fetchData();
  }, []);

  const handleCreate = async (e) => {
    e.preventDefault();
  
    const newProject = {
      title,
      startDate,
      endDate,
      description,
        customerId: parseInt(selectedCustomer, 10),  
        productId: parseInt(selectedProduct, 10),    
        userId: parseInt(selectedUser, 10) ,
        statusId: parseInt(selectedStatus, 10)
    };          
  
    console.log('Creating project with data:', newProject); // Lägg till logg för att se datan
  
    try {
      const result = await createProject(newProject);
      console.log('Project created:', result); // Logga svaret från servern
      navigate("/projects");
    } catch (error) {
      console.error("Error creating project", error);
    }
  };

  return (
    <div>
      <h1>Create New Project</h1>
      <form onSubmit={handleCreate}>
        <label>
          Project Title:
          <input
            type="text"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
            required
          />
        </label>

        <label>
          Description:
          <textarea
            value={description}
            onChange={(e) => setDescription(e.target.value)}
          />
        </label>

        <label>
          Start Date:
          <input
            type="date"
            value={startDate}
            onChange={(e) => setStartDate(e.target.value)}
            required
          />
        </label>

        <label>
          End Date:
          <input
            type="date"
            value={endDate}
            onChange={(e) => setEndDate(e.target.value)}
            required
          />
        </label>

        <label>
          Customer:
          <select
            value={selectedCustomer}
            onChange={(e) => setSelectedCustomer(e.target.value)}
            required
          >
            <option value="">Select Customer</option>
            {customers.map((customer) => (
              <option key={customer.id} value={customer.id}>
                {customer.customerName}
              </option>
            ))}
          </select>
        </label>

        

        <label>
          User:
          <select
            value={selectedUser}
            onChange={(e) => setSelectedUser(e.target.value)}
            required
          >
            <option value="">Select User</option>
            {users.map((user) => (
              <option key={user.id} value={user.id}>
                {user.firstName} {user.lastName}
              </option>
            ))}
          </select>
        </label>

        <label>
          Product:
          <select
            value={selectedProduct}
            onChange={(e) => setSelectedProduct(e.target.value)}
            required
          >
            <option value="">Select Product</option>
            {products.map((product) => (
              <option key={product.id} value={product.id}>
                {product.productName}
              </option>
            ))}
          </select>
        </label>

        <label>
          Status:
          <select
            value={selectedStatus}
            onChange={(e) => setSelectedStatus(e.target.value)}
            required
          >
            <option value="">Select Status</option>
            {statuses.map((status) => (
              <option key={status.id} value={status.id}>
                {status.statusName}
              </option>
            ))}
          </select>
        </label>

        

        <button onClick={handleCreate} type="submit">Create Project</button>
      </form>
    </div>
  );
};

export default CreateProjectPage;