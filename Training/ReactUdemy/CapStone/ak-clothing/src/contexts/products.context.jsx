import { createContext, useState, useEffect, useContext } from "react";
import PRODUCTS from "../shop-data.json";

export const ProductsContext = createContext({
  products: [],
  //setProducts: () => null,
});

export const ProductsProvider = ({ children }) => {
  const [products, setProducts] = useState(PRODUCTS);
  const value = { products };
  // useEffect(() => {

  // }, []);
  return <ProductsContext.Provider value={value}>{children}</ProductsContext.Provider>;
};
