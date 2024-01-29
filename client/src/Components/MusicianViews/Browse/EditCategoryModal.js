import React, { useEffect, useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import { getcategoryById, updateCategory } from '../../../Managers/categoryManager';
import "./Browse.css";

export const EditCategoryModal = ({categoryId, getAndSetAllCategories}) => {
    const [modal, setModal] = useState(false);
    const [category, setCategory] = useState({});
    const [newCategory, setNewCategory] = useState({
        
    });

    useEffect(() => { getAndSetCategory(categoryId) }, [categoryId]);

    useEffect(() => {
        if(category) { setNewCategory({id: categoryId,
            name:category.name,
            details: category.details,})}
    }, [category]);

    const getAndSetCategory = () => {
        getcategoryById(categoryId).then(setCategory);
    };

    const toggleModal = () => {
        setModal(!modal)
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        await updateCategory(newCategory);
        await getAndSetAllCategories();
        toggleModal();
    };

    return (
    <div>
      <Button id="edit-category-btn" className="create-btn" color='info' size='sm' onClick={toggleModal}>
        Edit
      </Button>
      <Modal isOpen={modal} toggle={toggleModal} style={{color:'black'}} backdrop="static">
        <ModalHeader toggle={toggleModal}>
            Edit Category:{" "}
            {newCategory.name}
        </ModalHeader>
        <ModalBody className='modal-body'>
            <input
                id='activity-name-input'
                value={newCategory.name}
                type='text'
                placeholder='Activity Name'
                onChange={(e) => {
                    const copy = {...newCategory};
                    copy.name = e.target.value;
                    setNewCategory(copy);
                }}
            />
            <textarea
                id='activity-details-input'
                value={newCategory.details}
                type='text'
                placeholder='Activity Description'
                onChange={(e) => {
                    const copy = {...newCategory};
                    copy.details = e.target.value;
                    setNewCategory(copy);
                }}
            />
        </ModalBody>
        <ModalFooter>
          <Button color="secondary" onClick={(e) => handleSubmit(e)}>
            Create Activity
          </Button>
        </ModalFooter>
      </Modal>
    </div>
  );
}