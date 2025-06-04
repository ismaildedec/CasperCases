import { useState, useEffect } from 'react'
import { Toaster, toast } from 'react-hot-toast'
import { PlusIcon, PencilSquareIcon, TrashIcon } from '@heroicons/react/24/outline'

const API_BASE = "http://localhost:5268/Products"

function App() {
  const [products, setProducts] = useState([])
  const [categories, setCategories] = useState([])
  const [editingProduct, setEditingProduct] = useState(null)
  const [formData, setFormData] = useState({
    name: '',
    price: '',
    categoryId: ''
  })

  useEffect(() => {
    fetchProducts()
    fetchCategories()
  }, [])

  const fetchProducts = async () => {
    try {
      const response = await fetch(API_BASE)
      const data = await response.json()
      setProducts(data)
    } catch (error) {
      toast.error('Ürünler yüklenirken bir hata oluştu')
    }
  }

  const fetchCategories = async () => {
    try {
      const response = await fetch(`${API_BASE}/categories`)
      const data = await response.json()
      setCategories(data)
    } catch (error) {
      toast.error('Kategoriler yüklenirken bir hata oluştu')
    }
  }

  const handleSubmit = async (e) => {
    e.preventDefault()
    try {
      const method = editingProduct ? 'PUT' : 'POST'
      const url = editingProduct ? `${API_BASE}/${editingProduct.id}` : API_BASE

      const response = await fetch(url, {
        method,
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          name: formData.name,
          price: parseFloat(formData.price),
          categoryId: parseInt(formData.categoryId)
        })
      })

      if (response.ok) {
        toast.success(editingProduct ? 'Ürün güncellendi' : 'Ürün eklendi')
        resetForm()
        fetchProducts()
      } else {
        throw new Error()
      }
    } catch (error) {
      toast.error(editingProduct ? 'Ürün güncellenemedi' : 'Ürün eklenemedi')
    }
  }

  const handleDelete = async (id) => {
    if (!window.confirm('Bu ürünü silmek istediğinize emin misiniz?')) return

    try {
      const response = await fetch(`${API_BASE}/${id}`, { method: 'DELETE' })
      if (response.ok) {
        toast.success('Ürün silindi')
        fetchProducts()
      } else {
        throw new Error()
      }
    } catch (error) {
      toast.error('Ürün silinemedi')
    }
  }

  const handleEdit = (product) => {
    setEditingProduct(product)
    const category = categories.find(c => c.name === product.category)
    setFormData({
      name: product.name,
      price: product.price,
      categoryId: category?.id || ''
    })
  }

  const resetForm = () => {
    setEditingProduct(null)
    setFormData({ name: '', price: '', categoryId: '' })
  }

  return (
    <div className="min-h-screen bg-gray-50 py-8">
      <Toaster position="top-right" />
      
      <div className="max-w-4xl mx-auto px-4">
        <h1 className="text-2xl font-semibold text-gray-800 mb-6">Ürün Yönetimi</h1>

        {/* Form */}
        <div className="bg-white rounded-lg shadow p-6 mb-6">
          <form onSubmit={handleSubmit} className="space-y-4">
            <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Ürün Adı</label>
                <input
                  type="text"
                  value={formData.name}
                  onChange={(e) => setFormData(prev => ({ ...prev, name: e.target.value }))}
                  className="w-full rounded border-gray-300 shadow-sm focus:ring-blue-500 focus:border-blue-500"
                  required
                />
              </div>

              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Fiyat</label>
                <input
                  type="number"
                  value={formData.price}
                  onChange={(e) => setFormData(prev => ({ ...prev, price: e.target.value }))}
                  className="w-full rounded border-gray-300 shadow-sm focus:ring-blue-500 focus:border-blue-500"
                  required
                />
              </div>

              <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Kategori</label>
                <select
                  value={formData.categoryId}
                  onChange={(e) => setFormData(prev => ({ ...prev, categoryId: e.target.value }))}
                  className="w-full rounded border-gray-300 shadow-sm focus:ring-blue-500 focus:border-blue-500"
                  required
                >
                  <option value="">Seçiniz</option>
                  {categories.map(category => (
                    <option key={category.id} value={category.id}>
                      {category.name}
                    </option>
                  ))}
                </select>
              </div>
            </div>

            <div className="flex gap-2">
              <button
                type="submit"
                className="inline-flex items-center px-4 py-2 bg-blue-600 text-white text-sm font-medium rounded-md hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500"
              >
                {editingProduct ? (
                  <>
                    <PencilSquareIcon className="h-4 w-4 mr-2" />
                    Güncelle
                  </>
                ) : (
                  <>
                    <PlusIcon className="h-4 w-4 mr-2" />
                    Ekle
                  </>
                )}
              </button>
              
              {editingProduct && (
                <button
                  type="button"
                  onClick={resetForm}
                  className="inline-flex items-center px-4 py-2 border border-gray-300 text-sm font-medium rounded-md text-gray-700 bg-white hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500"
                >
                  İptal
                </button>
              )}
            </div>
          </form>
        </div>

        {/* Tablo */}
        <div className="bg-white rounded-lg shadow overflow-hidden">
          <div className="overflow-x-auto">
            <table className="min-w-full divide-y divide-gray-200">
              <thead className="bg-gray-50">
                <tr>
                  <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Ürün Adı</th>
                  <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Fiyat</th>
                  <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase">Kategori</th>
                  <th className="px-6 py-3 text-right text-xs font-medium text-gray-500 uppercase">İşlemler</th>
                </tr>
              </thead>
              <tbody className="bg-white divide-y divide-gray-200">
                {products.map(product => (
                  <tr key={product.id} className="hover:bg-gray-50">
                    <td className="px-6 py-4 text-sm font-medium text-gray-900">{product.name}</td>
                    <td className="px-6 py-4 text-sm text-gray-500">{product.price} ₺</td>
                    <td className="px-6 py-4 text-sm text-gray-500">{product.category}</td>
                    <td className="px-6 py-4 text-right text-sm font-medium">
                      <button
                        onClick={() => handleEdit(product)}
                        className="text-blue-600 hover:text-blue-900 mr-3"
                      >
                        <PencilSquareIcon className="h-5 w-5" />
                      </button>
                      <button
                        onClick={() => handleDelete(product.id)}
                        className="text-red-600 hover:text-red-900"
                      >
                        <TrashIcon className="h-5 w-5" />
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
  )
}

export default App 