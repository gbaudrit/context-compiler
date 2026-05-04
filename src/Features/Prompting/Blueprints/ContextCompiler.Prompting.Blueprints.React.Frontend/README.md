# React Frontend Application Blueprint

## Overview

The **ContextCompiler.Prompting.Blueprints.React.Frontend** blueprint provides comprehensive, step-by-step guidance for building modern, production-ready React applications with TypeScript, component architecture, state management, routing, and best practices.

## What This Blueprint Provides

This blueprint guides you through **17 detailed steps** to build a complete React frontend:

1. ✅ **Project Initialization** - Vite or Create React App with TypeScript
2. ✅ **TypeScript & ESLint** - Strict typing and code quality
3. ✅ **React Router** - Client-side routing with lazy loading
4. ✅ **Component Architecture** - Presentational vs container patterns
5. ✅ **State Management** - useState, Context, Redux/Zustand
6. ✅ **Custom Hooks** - Reusable logic abstraction
7. ✅ **API Integration** - Axios/Fetch with typed services
8. ✅ **Authentication** - JWT storage, protected routes
9. ✅ **Forms & Validation** - React Hook Form with Yup/Zod
10. ✅ **Styling** - CSS Modules, Styled Components, or Tailwind
11. ✅ **Error Handling** - Error boundaries and logging
12. ✅ **Performance** - Memoization, lazy loading, optimization
13. ✅ **Accessibility** - WCAG compliance, keyboard navigation
14. ✅ **Testing** - Jest, React Testing Library, MSW
15. ✅ **Environment Config** - Multi-environment variables
16. ✅ **Monitoring** - Analytics, performance, error tracking
17. ✅ **Deployment** - CI/CD, hosting, optimization

## Key Features

### 🎨 Modern React
- **React 18+** with concurrent features
- **TypeScript** for type safety
- **Functional components** with hooks
- **Latest ECMAScript** features

### 🏗️ Architecture
- **Component-based** modular design
- **Feature-based** folder structure
- **Service layer** for API abstraction
- **Custom hooks** for reusable logic

### 🔐 Security & Auth
- **JWT authentication** with secure storage
- **Protected routes** with redirects
- **Token refresh** for seamless UX
- **HTTPS enforcement**

### ⚡ Performance
- **Code splitting** with React.lazy
- **Memoization** (React.memo, useMemo, useCallback)
- **Lazy loading** images and components
- **Bundle optimization**

### ♿ Accessibility
- **WCAG 2.1 Level AA** compliance
- **Semantic HTML** elements
- **Keyboard navigation**
- **Screen reader** support

### 🧪 Testing
- **React Testing Library** for components
- **Jest** for unit tests
- **MSW** for API mocking
- **>80% coverage** target

## Installation

### NuGet Package
```bash
dotnet add package ContextCompiler.Prompting.Blueprints.React.Frontend
```

### Configuration
Add to your `modules.config.json`:
```json
{
  "modules": [
    {
      "id": "react-frontend",
      "package": "ContextCompiler.Prompting.Blueprints.React.Frontend",
      "version": "1.0.0"
    }
  ]
}
```

## Example: Building a Product Dashboard

### Step 1: Initialize Project with Vite

```bash
npm create vite@latest product-dashboard -- --template react-ts
cd product-dashboard
npm install
```

**Folder Structure:**
```
src/
├── components/        # Reusable UI components
│   ├── Button/
│   ├── Card/
│   └── Layout/
├── pages/            # Page components
│   ├── Home/
│   ├── Products/
│   └── Login/
├── hooks/            # Custom hooks
│   ├── useAuth.ts
│   └── useFetch.ts
├── services/         # API services
│   └── api.ts
├── types/            # TypeScript types
│   └── Product.ts
├── utils/            # Utility functions
│   └── formatters.ts
└── App.tsx
```

### Step 2-3: Configure TypeScript and Routing

**tsconfig.json:**
```json
{
  "compilerOptions": {
    "target": "ES2020",
    "strict": true,
    "baseUrl": ".",
    "paths": {
      "@/*": ["./src/*"],
      "@/components/*": ["./src/components/*"],
      "@/hooks/*": ["./src/hooks/*"]
    }
  }
}
```

**Router Setup (App.tsx):**
```tsx
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import { Suspense, lazy } from 'react';

// Lazy-loaded pages
const Home = lazy(() => import('@/pages/Home'));
const Products = lazy(() => import('@/pages/Products'));
const Login = lazy(() => import('@/pages/Login'));

const ProtectedRoute = ({ children }: { children: React.ReactNode }) => {
  const { isAuthenticated } = useAuth();
  return isAuthenticated ? <>{children}</> : <Navigate to="/login" />;
};

function App() {
  return (
    <BrowserRouter>
      <Suspense fallback={<div>Loading...</div>}>
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route path="/" element={
            <ProtectedRoute>
              <Home />
            </ProtectedRoute>
          } />
          <Route path="/products" element={
            <ProtectedRoute>
              <Products />
            </ProtectedRoute>
          } />
          <Route path="*" element={<div>404 Not Found</div>} />
        </Routes>
      </Suspense>
    </BrowserRouter>
  );
}
```

### Step 4: Component Architecture

**Product Card Component (components/ProductCard/ProductCard.tsx):**
```tsx
interface ProductCardProps {
  id: number;
  name: string;
  price: number;
  imageUrl: string;
  onAddToCart: (id: number) => void;
}

export const ProductCard: React.FC<ProductCardProps> = ({ 
  id, 
  name, 
  price, 
  imageUrl, 
  onAddToCart 
}) => {
  const handleClick = () => {
    onAddToCart(id);
  };

  return (
    <div className="product-card">
      <img src={imageUrl} alt={name} loading="lazy" />
      <h3>{name}</h3>
      <p>${price.toFixed(2)}</p>
      <button onClick={handleClick}>Add to Cart</button>
    </div>
  );
};
```

### Step 5-6: State Management with Custom Hooks

**Auth Context (contexts/AuthContext.tsx):**
```tsx
import { createContext, useContext, useState, useCallback } from 'react';

interface AuthContextType {
  isAuthenticated: boolean;
  user: User | null;
  login: (email: string, password: string) => Promise<void>;
  logout: () => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const [user, setUser] = useState<User | null>(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  const login = useCallback(async (email: string, password: string) => {
    const response = await authService.login(email, password);
    localStorage.setItem('token', response.token);
    setUser(response.user);
    setIsAuthenticated(true);
  }, []);

  const logout = useCallback(() => {
    localStorage.removeItem('token');
    setUser(null);
    setIsAuthenticated(false);
  }, []);

  return (
    <AuthContext.Provider value={{ isAuthenticated, user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error('useAuth must be used within AuthProvider');
  }
  return context;
};
```

**Custom Fetch Hook (hooks/useFetch.ts):**
```tsx
import { useState, useEffect } from 'react';

interface UseFetchResult<T> {
  data: T | null;
  loading: boolean;
  error: Error | null;
  refetch: () => void;
}

export function useFetch<T>(url: string): UseFetchResult<T> {
  const [data, setData] = useState<T | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<Error | null>(null);

  const fetchData = async () => {
    try {
      setLoading(true);
      const response = await fetch(url);
      if (!response.ok) throw new Error('Network error');
      const json = await response.json();
      setData(json);
      setError(null);
    } catch (err) {
      setError(err as Error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchData();
  }, [url]);

  return { data, loading, error, refetch: fetchData };
}
```

### Step 7: API Service Layer

**API Client (services/api.ts):**
```tsx
import axios from 'axios';

const apiClient = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL || 'http://localhost:3000/api',
  timeout: 10000,
});

// Request interceptor for auth tokens
apiClient.interceptors.request.use((config) => {
  const token = localStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

// Response interceptor for error handling
apiClient.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response?.status === 401) {
      // Handle unauthorized
      localStorage.removeItem('token');
      window.location.href = '/login';
    }
    return Promise.reject(error);
  }
);

export default apiClient;
```

**Product Service (services/productService.ts):**
```tsx
import apiClient from './api';

export interface Product {
  id: number;
  name: string;
  price: number;
  description: string;
  imageUrl: string;
}

export const productService = {
  getAll: async (): Promise<Product[]> => {
    const response = await apiClient.get<Product[]>('/products');
    return response.data;
  },

  getById: async (id: number): Promise<Product> => {
    const response = await apiClient.get<Product>(`/products/${id}`);
    return response.data;
  },

  create: async (product: Omit<Product, 'id'>): Promise<Product> => {
    const response = await apiClient.post<Product>('/products', product);
    return response.data;
  },

  update: async (id: number, product: Partial<Product>): Promise<Product> => {
    const response = await apiClient.put<Product>(`/products/${id}`, product);
    return response.data;
  },

  delete: async (id: number): Promise<void> => {
    await apiClient.delete(`/products/${id}`);
  },
};
```

### Step 9: Form Handling with React Hook Form

```bash
npm install react-hook-form @hookform/resolvers yup
```

**Login Form (pages/Login/LoginForm.tsx):**
```tsx
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from 'yup';
import { useAuth } from '@/hooks/useAuth';

interface LoginFormData {
  email: string;
  password: string;
}

const schema = yup.object({
  email: yup.string().email('Invalid email').required('Email is required'),
  password: yup.string().min(6, 'Minimum 6 characters').required('Password is required'),
});

export const LoginForm: React.FC = () => {
  const { login } = useAuth();
  const { 
    register, 
    handleSubmit, 
    formState: { errors, isSubmitting } 
  } = useForm<LoginFormData>({
    resolver: yupResolver(schema),
  });

  const onSubmit = async (data: LoginFormData) => {
    await login(data.email, data.password);
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <div>
        <label htmlFor="email">Email</label>
        <input 
          id="email"
          type="email" 
          {...register('email')} 
          aria-invalid={errors.email ? 'true' : 'false'}
        />
        {errors.email && (
          <span role="alert" className="error">{errors.email.message}</span>
        )}
      </div>

      <div>
        <label htmlFor="password">Password</label>
        <input 
          id="password"
          type="password" 
          {...register('password')}
          aria-invalid={errors.password ? 'true' : 'false'}
        />
        {errors.password && (
          <span role="alert" className="error">{errors.password.message}</span>
        )}
      </div>

      <button type="submit" disabled={isSubmitting}>
        {isSubmitting ? 'Logging in...' : 'Login'}
      </button>
    </form>
  );
};
```

### Step 11: Error Boundary

**ErrorBoundary Component:**
```tsx
import { Component, ErrorInfo, ReactNode } from 'react';

interface Props {
  children: ReactNode;
  fallback?: ReactNode;
}

interface State {
  hasError: boolean;
  error?: Error;
}

export class ErrorBoundary extends Component<Props, State> {
  public state: State = {
    hasError: false,
  };

  public static getDerivedStateFromError(error: Error): State {
    return { hasError: true, error };
  }

  public componentDidCatch(error: Error, errorInfo: ErrorInfo) {
    console.error('Uncaught error:', error, errorInfo);
    // Send to error tracking service (Sentry, etc.)
  }

  public render() {
    if (this.state.hasError) {
      return this.props.fallback || (
        <div role="alert">
          <h1>Something went wrong</h1>
          <p>{this.state.error?.message}</p>
          <button onClick={() => this.setState({ hasError: false })}>
            Try again
          </button>
        </div>
      );
    }

    return this.props.children;
  }
}
```

### Step 12: Performance Optimization

**Memoized Component:**
```tsx
import { memo, useCallback, useMemo } from 'react';

interface ProductListProps {
  products: Product[];
  onProductClick: (id: number) => void;
}

export const ProductList: React.FC<ProductListProps> = memo(({ products, onProductClick }) => {
  // Memoize expensive computation
  const sortedProducts = useMemo(() => {
    return [...products].sort((a, b) => a.name.localeCompare(b.name));
  }, [products]);

  // Memoize callback to prevent child re-renders
  const handleClick = useCallback((id: number) => {
    onProductClick(id);
  }, [onProductClick]);

  return (
    <div>
      {sortedProducts.map(product => (
        <ProductCard 
          key={product.id}
          {...product}
          onClick={handleClick}
        />
      ))}
    </div>
  );
});

ProductList.displayName = 'ProductList';
```

### Step 14: Testing with React Testing Library

```bash
npm install --save-dev @testing-library/react @testing-library/jest-dom @testing-library/user-event msw
```

**Component Test (ProductCard.test.tsx):**
```tsx
import { render, screen, fireEvent } from '@testing-library/react';
import { ProductCard } from './ProductCard';

describe('ProductCard', () => {
  const mockProduct = {
    id: 1,
    name: 'Test Product',
    price: 29.99,
    imageUrl: 'test.jpg',
  };

  const mockOnAddToCart = jest.fn();

  it('renders product information', () => {
    render(<ProductCard {...mockProduct} onAddToCart={mockOnAddToCart} />);
    
    expect(screen.getByText('Test Product')).toBeInTheDocument();
    expect(screen.getByText('$29.99')).toBeInTheDocument();
    expect(screen.getByAltText('Test Product')).toBeInTheDocument();
  });

  it('calls onAddToCart when button clicked', () => {
    render(<ProductCard {...mockProduct} onAddToCart={mockOnAddToCart} />);
    
    const button = screen.getByRole('button', { name: /add to cart/i });
    fireEvent.click(button);
    
    expect(mockOnAddToCart).toHaveBeenCalledWith(1);
  });
});
```

## Benefits

✅ **Modern Stack**: React 18, TypeScript, latest tooling  
✅ **Type-Safe**: TypeScript prevents runtime errors  
✅ **Performant**: Code splitting, lazy loading, memoization  
✅ **Accessible**: WCAG compliance, keyboard navigation  
✅ **Testable**: High coverage with Testing Library  
✅ **Maintainable**: Clear architecture, small components  
✅ **Secure**: JWT auth, protected routes, HTTPS  
✅ **Deployable**: CI/CD ready, optimized builds

## Related Blueprints

- **ContextCompiler.Prompting.Blueprints.DotNet.Api.Backend** - For REST API backend
- **ContextCompiler.Prompting.Blueprints.Agile.UserStory** - For requirements documentation

## Requirements

- Node.js 18+ and npm/yarn
- React 18+
- TypeScript 5+
- Modern browser support (ES6+)

## License

MIT License - See LICENSE.txt for details

## Support

For issues and questions, visit [GitHub Issues](https://github.com/gbaudrit/context-compiler/issues)

---

**Built with ContextCompiler** - Structured guidance for React development
