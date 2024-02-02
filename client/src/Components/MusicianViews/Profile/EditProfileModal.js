import React, { useEffect, useState } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import "./Profile.css";
import { updateUserProfile } from '../../../Managers/profileManager';

export const EditProfileModal = ({ user, loggedInUser, getAndSetUser}) => {
    const [modal, setModal] = useState(false);
    const [updatedUser, setUpdatedUser] = useState({});

    useEffect(() => {
        if(user.id)
        {
            setUpdatedUser({
                id: user.id,
                identityUserId: user.identityUserId,
                firstName: user.firstName,
                lastName: user.lastName, 
                address: user.address,
                email: user.email,
                userName: user.userName
            })
        }
    }, [user])

    const toggleModal = () => {
        setModal(!modal)
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        await updateUserProfile(updatedUser);
        await getAndSetUser(user.id);
        toggleModal();
    }

    return (
    <div>
      <Button id="edit-profile-btn" className="create-btn" color='info' size='sm' onClick={toggleModal}>
        Edit Profile
      </Button>
      <Modal isOpen={modal} toggle={toggleModal} style={{color:'black'}} backdrop="static">
        <ModalHeader toggle={toggleModal}>
            Edit User Profile
        </ModalHeader>
        {loggedInUser?.roles[0] === "Teacher" || loggedInUser.id === user.id
        ?    <ModalBody className='modal-body'>
            
                <label>First Name
                    <input
                        required
                        id='first-name-input'
                        value={updatedUser.firstName}
                        type='text'
                        onChange={(e) => {
                            const copy = {...updatedUser}
                            copy.firstName = e.target.value
                            setUpdatedUser(copy);
                        }}
                    />
                </label>

                <label>Last Name
                    <input
                        required
                        id='last-name-input'
                        value={updatedUser.lastName}
                        type='text'
                        onChange={(e) => {
                            const copy = {...updatedUser}
                            copy.lastName = e.target.value
                            setUpdatedUser(copy);
                        }}
                    />
                </label>

                <label>Address
                    <input
                        required
                        id='address-input'
                        value={updatedUser.address}
                        type='text'
                        onChange={(e) => {
                            const copy = {...updatedUser}
                            copy.address = e.target.value
                            setUpdatedUser(copy);
                        }}
                    />
                </label>

                <label>Email
                    <input
                        required
                        id='email-input'
                        value={updatedUser.email}
                        type='email'
                        onChange={(e) => {
                            const copy = {...updatedUser}
                            copy.email = e.target.value
                            setUpdatedUser(copy);
                        }}
                    />
                </label>

                <label>Username
                    <input
                        required
                        id='username-input'
                        value={updatedUser.userName}
                        type='text'
                        onChange={(e) => {
                            const copy = {...updatedUser}
                            copy.userName = e.target.value
                            setUpdatedUser(copy);
                        }}
                    />
                </label>

            </ModalBody>
            : 
                <ModalBody className='modal-body'>
                    <h4>Not Authorized to edit this user</h4>
                </ModalBody>
            }
            <ModalFooter>
                {updatedUser.firstName &&
                updatedUser.lastName &&
                updatedUser.email &&
                updatedUser.address &&
                updatedUser.userName &&
                updatedUser.identityUserId
                ?
                    <Button color="secondary" onClick={(e) => handleSubmit(e)}>
                        Update Profile
                    </Button> 
                : null}
            </ModalFooter>
      </Modal>
    </div>
  );
}