import React, { useState, useEffect } from "react";
import { getProjectById, updateProject, getCustomers, getProducts, getUsers, getStatuses } from "../services/projectService";
import { useParams, useNavigate } from "react-router-dom";

const EditProjectPage = () => {
  const [project, setProject] = useState(null);
  const [customers, setCustomers] = useState([]);
  const [products, setProducts] = useState([]);
  const [users, setUsers] = useState([]);
  const [statuses, setStatuses] = useState([]);
  const [selectedCustomer, setSelectedCustomer] = useState("");
  const [selectedProduct, setSelectedProduct] = useState("");
  const [selectedUser, setSelectedUser] = useState("");
  const [selectedStatus, setSelectedStatus] = useState("");
  const { id } = useParams();
  const navigate = useNavigate();

  // Hämta data vid laddning av sidan
  useEffect(() => {
    const fetchData = async () => {
      try {
        // Hämta projektet med getProjectById
        const projectData = await getProjectById(id);
        setProject(projectData);

        // Hämta alla kunder med getCustomers
        const customerData = await getCustomers();
        setCustomers(customerData);

        // Hämta alla produkter med getProducts
        const productData = await getProducts();
        setProducts(productData);

        // Hämta alla användare med getUsers
        const userData = await getUsers();
        setUsers(userData);

        // Hämta alla statusar med getStatuses
        const statusData = await getStatuses();
        setStatuses(statusData);

        // Sätt initiala värden för de valda fälten
        setSelectedCustomer(projectData.customerId);
        setSelectedProduct(projectData.productId);
        setSelectedUser(projectData.userId);
        setSelectedStatus(projectData.statusId);
      } catch (error) {
        console.error("Error fetching data", error);
      }
    };

    fetchData();
  }, [id]);

  // Uppdatera projektet
  const handleUpdate = async (e) => {
    e.preventDefault();

    const updatedProject = {
      title: project.title,  // Vi använder den oförändrade titeln här
      description: project.description,
      startDate: project.startDate,
      endDate: project.endDate,
      customerId: parseInt(selectedCustomer, 10),
      productId: parseInt(selectedProduct, 10),
      userId: parseInt(selectedUser, 10),
      statusId: parseInt(selectedStatus, 10),
    };

    try {
      await updateProject(id, updatedProject);
      navigate("/projects"); // Navigera tillbaka till projektlistan efter uppdatering
    } catch (error) {
      console.error("Error updating project", error);
    }
  };

  if (!project) {
    return <div>Loading...</div>; // Vänta på att projektet ska laddas
  }

  return (
    <div>
      <h1>Edit Project</h1>
      <form onSubmit={handleUpdate}>
        {/* Visa titeln som en statisk text (h4) */}
        <label>
          Project Title:
          <h4>{project.title}</h4>  {/* Här visas titeln som statisk text */}
        </label>

        <label>
          Description:
          <textarea
            value={project.description}
            onChange={(e) => setProject({ ...project, description: e.target.value })}
            required
          />
        </label>

        <label>
          Start Date:
          <input
            type="date"
            value={project.startDate}
            onChange={(e) => setProject({ ...project, startDate: e.target.value })}
            required
          />
        </label>

        <label>
          End Date:
          <input
            type="date"
            value={project.endDate}
            onChange={(e) => setProject({ ...project, endDate: e.target.value })}
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

        <button type="submit">Update Project</button>
      </form>
    </div>
  );
};

export default EditProjectPage;