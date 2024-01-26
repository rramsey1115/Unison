import React, { useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

export const ConfirmDeleteCatModal = ({handleDeleteCategory, category}) => {
    const [modal, setModal] = useState(false);

    const toggle = () => setModal(!modal);

    return (
        <div>
            <Button
                id="delete-category-btn"
                className="delete-btn"
                color="secondary"
                size="sm"
                value={category.id}
                onClick={toggle}
            >Delete
            </Button>
            <Modal isOpen={modal} toggle={toggle} style={{color:'black'}} size='md'>
                <ModalHeader toggle={toggle}>Warning</ModalHeader>
                <ModalBody >
                    <h5>Are you sure you want to delete category</h5>
                    <h4>{category.name}</h4>
                    <h5>This action is permanent and cannot be undone.</h5>
                </ModalBody>
                <ModalFooter>
                    <Button 
                        color="info" 
                        value={category.id}
                        onClick={(e) => {handleDeleteCategory(e); toggle();}}>
                        Delete Category
                    </Button>{' '}
                    <Button 
                        color="secondary"
                        onClick={toggle}
                    >Cancel
                    </Button>
                </ModalFooter>
            </Modal>
        </div>
    )
}