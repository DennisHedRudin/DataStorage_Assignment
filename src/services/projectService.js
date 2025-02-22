import axios from "axios";

// Bas-URL för API (ändra till din API-URL)
const API_URL = "https://localhost:7120/api/project";

// Hämta alla projekt
export const getAllProjects = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data.result; // Returnera listan av projekt
  } catch (error) {
    console.error("Error fetching projects", error);
    throw error;
  }
};

export const getProjectById = async (id) => {
    const response = await fetch(`https://localhost:7120/api/project/${id}`);
    const data = await response.json();
    return data;
  };

  // Hämta alla kunder
export const getCustomers = async () => {
    try {
      const response = await axios.get("https://localhost:7120/api/project/customers");
      return response.data; // Returnera listan med kunder
    } catch (error) {
      console.error("Error fetching customers", error);
      throw error;
    }
  };
  
  // Hämta alla produkter
  export const getProducts = async () => {
    try {
      const response = await axios.get("https://localhost:7120/api/project/products");
      console.log('Fetched products:', response.data);  // Logga för att se datat
      return response.data.result; // Returnera data
    } catch (error) {
      console.error("Error fetching products", error);
      throw error;
    }
  };
  
  // Hämta alla användare
  export const getUsers = async () => {
    try {
      const response = await axios.get("https://localhost:7120/api/project/users");
      return response.data; // Returnera listan med användare
    } catch (error) {
      console.error("Error fetching users", error);
      throw error;
    }
  };

  export const getStatuses = async () => {
    try {
      const response = await axios.get("https://localhost:7120/api/project/statuses");
      return response.data; 
    } catch (error) {
      console.error("Error fetching statuses", error);
      throw error;
    }
  };

// Skapa ett nytt projekt
export const createProject = async (projectData) => {
  try {
    const response = await axios.post(API_URL, projectData);
    return response.data; // Returnera det skapade projektet
  } catch (error) {
    console.error("Error creating project", error);
    throw error;
  }
};

// Uppdatera ett befintligt projekt
export const updateProject = async (id, projectData) => {
  try {
    const response = await axios.put(`${API_URL}/${id}`, projectData);
    return response.data; // Returnera det uppdaterade projektet
  } catch (error) {
    console.error("Error updating project", error);
    throw error;
  }
};

// Ta bort ett projekt
export const deleteProject = async (id) => {
  try {
    await axios.delete(`${API_URL}/${id}`);
  } catch (error) {
    console.error("Error deleting project", error);
    throw error;
  }
};