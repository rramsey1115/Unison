import React, { useEffect, useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import { getcategoryById } from '../../../../Managers/categoryManager';
import { postNewActivity } from '../../../../Managers/activityManager';

export const CreateActivityModal = ({categoryId, getAndSetActivities}) => {
    const [modal, setModal] = useState(false);
    const [category, setCategory] = useState({});
    const [newActivity, setNewActivity] = useState({
        name:"",
        details: "",
        categoryId: categoryId
    });

    useEffect(() => { getAndSetCategory(categoryId) }, [categoryId]);

    const toggle = () => {
        setModal(!modal)
    };

    const getAndSetCategory = (categoryId) => {
        getcategoryById(categoryId).then(setCategory);
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        await postNewActivity(newActivity)
        await getAndSetActivities(categoryId)
        toggle();
    }

    return (
    <div>
      <button id="create-activity-btn" className="create-btn" onClick={toggle}>
        Create Activity
      </button>
      <Modal isOpen={modal} toggle={toggle} style={{color:'black'}} backdrop="static">
        <ModalHeader toggle={toggle}>
            <h5>Add to category:</h5>
            {category.name}
        </ModalHeader>
        <ModalBody className='modal-body'>
            
            <input
                id='activity-name-input'
                value={newActivity.name}
                type='text'
                placeholder='Activity Name'
                onChange={(e) => {
                    const copy = {...newActivity};
                    copy.name = e.target.value;
                    setNewActivity(copy);
                }}
            />

            <textarea
                id='activity-details-input'
                value={newActivity.details}
                type='text'
                placeholder='Activity Description'
                onChange={(e) => {
                    const copy = {...newActivity};
                    copy.details = e.target.value;
                    setNewActivity(copy);
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