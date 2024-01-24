import React, { useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import "./Browse.css";
import { createCategory } from '../../../Managers/categoryManager';

export const CreateCategoryModal = ({getAndSetAllCategories, loggedInUser}) => {
    const [modal, setModal] = useState(false);
    const [createdCategory, setCreatedCategory] = useState({name: "", details: ""});

    const toggleModal = () => {
        setModal(!modal)
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        console.log("createdCategory", createdCategory);
        await createCategory(createdCategory);
        await getAndSetAllCategories();
        toggleModal();
    }

    return (
    <div>
      <Button id="create-category-btn" className="create-btn" color='info' size='sm' onClick={toggleModal}>
        Create Category
      </Button>
      <Modal isOpen={modal} toggle={toggleModal} style={{color:'black'}} backdrop="static">
        <ModalHeader toggle={toggleModal}>
            Create New Category
        </ModalHeader>
        <ModalBody className='modal-body'>
            
            <input
                id='category-name-input'
                value={createdCategory.name}
                type='text'
                placeholder='Category Name'
                onChange={(e) => {
                    const copy = {...createdCategory};
                    copy.name = e.target.value;
                    setCreatedCategory(copy);
                }}
            />

            <textarea
                id='category-details-input'
                value={createdCategory.details}
                type='text'
                placeholder='Category Description'
                onChange={(e) => {
                    const copy = {...createdCategory};
                    copy.details = e.target.value;
                    setCreatedCategory(copy);
                }}
            />

        </ModalBody>
        <ModalFooter>
          <Button color="secondary" onClick={(e) => handleSubmit(e)}>
            Create Category
          </Button>
        </ModalFooter>
      </Modal>
    </div>
  );
}